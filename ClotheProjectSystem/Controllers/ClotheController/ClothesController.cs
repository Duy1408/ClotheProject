﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClotheBusinessObject.BusinessObject;
using Service.Interface;
using SQLitePCL;
using AutoMapper;
using ClotheBusinessObject.ViewModel;
using Azure.Storage.Blobs;
using ClotheBusinessObject.DTO.Create;
using ClotheBusinessObject.DTO.Request;

namespace ClotheProjectSystem.Controllers.ClotheController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClotheService _clothe;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;


        public ClothesController(IClotheService clothe, IMapper mapper, BlobServiceClient blobServiceClient)
        {
            _clothe = clothe;
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;

        }

        // GET: api/Clothes
        [HttpGet]
        public ActionResult<IEnumerable<Clothe>> GetClothes()
        {
            try { 
            if (_clothe.GetAllClothe() == null)
            {
                return NotFound();
            }
            var clothes = _clothe.GetAllClothe();
            var response = _mapper.Map<List<ClotheVM>>(clothes);
           
            return Ok(response);
        }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }

        //// GET: api/Clothes/5
        //[HttpGet("{id}")]


        //public ActionResult<Clothe> GetClothe(Guid id)
        //{
        //    if (_clothe.GetAllClothe() == null)
        //    {
        //        return NotFound();
        //    }
        //    var clothe = _clothe.GetClotheByID(id);

        //    if (clothe == null)
        //    {
        //        return NotFound();
        //    }

        //    return clothe;
        //}

        [HttpGet("GetClotheByID/{id}")]
        public IActionResult GetClotheByID(Guid id)
        {

            var clothe = _clothe.GetClotheByID(id);

            if (clothe != null)
            {
                var responese = _mapper.Map<ClotheVM>(clothe);

                return Ok(responese);
            }

            return NotFound();

        }
        // PUT: api/Clothes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClothe(Guid id, Clothe clothe)
        {
            if (_clothe.GetAllClothe() == null)
            {
                return BadRequest();
            }



            try
            {
                _clothe.UpdateClothe(clothe);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_clothe.GetAllClothe() == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clothes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Clothe> PostClothe([FromForm] ClotheRequestDTO clothe)
        {

            try
            {
                var containerInstance = _blobServiceClient.GetBlobContainerClient("theclotheppictures");
                string? bloUrl = null;
                if (clothe.Image != null)
                {
                    var blobName = $"{Guid.NewGuid()}_{clothe.Image.FileName}";
                    var blobInstance = containerInstance.GetBlobClient(blobName);
                    blobInstance.Upload(clothe.Image.OpenReadStream());
                    var storageAccountUrl = "https://clotheimage.blob.core.windows.net/theclotheppictures";
                    bloUrl = $"{storageAccountUrl}/{blobName}";
                }
                var newClothe = new ClotheCreateDTO
                {
                    ClotheID = Guid.NewGuid(),
                    ClotheName = clothe.ClotheName,
                    Price = clothe.Price,
                    Description = clothe.Description,
                    Rent = clothe.Rent,
                    Image = clothe.Image,
                    ShopID = clothe.ShopID,
                    Status = true,

                };
                var _clo = _mapper.Map<Clothe>(newClothe);
                _clo.Image = bloUrl;
                _clothe.AddNewClothe(_clo);
                return Ok("create clothe successfully");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //if (_clothe.GetAllClothe() == null)
            //{
            //    return Problem("Entity set 'ClotheShopSystemDBContext.Clothes'  is null.");
            //}
            //_clothe.AddNewClothe(clothe);

            //return CreatedAtAction("GetClothe", new { id = clothe.ClotheID }, clothe);
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothe(Guid id)
        {
            if (_clothe.GetAllClothe() == null)
            {
                return NotFound();
            }
            var clothe = _clothe.GetClotheByID(id);
            if (clothe == null)
            {
                return NotFound();
            }

            _clothe.ChangeStatusClothe(clothe);


            return NoContent();
        }
    }
}
