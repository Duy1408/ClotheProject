using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClotheBusinessObject.BusinessObject;
using Service.Interface;
using SQLitePCL;

namespace ClotheProjectSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClotheService _clothe;

        public ClothesController(IClotheService clothe)
        {
           _clothe = clothe;
        }

        // GET: api/Clothes
        [HttpGet]
        public ActionResult<IEnumerable<Clothe>> GetClothes()
        {
          if (_clothe.GetAllClothe() == null)
          {
              return NotFound();
          }
            return  _clothe.GetAllClothe().ToList();
        }

        // GET: api/Clothes/5
        [HttpGet("{id}")]
        public ActionResult<Clothe> GetClothe(Guid id)
        {
            if (_clothe.GetAllClothe() == null)
            {
                return NotFound();
            }
            var clothe =  _clothe.GetClotheByID(id);

            if (clothe == null)
            {
                return NotFound();
            }

            return clothe;
        }

        // PUT: api/Clothes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClothe(Guid id, Clothe clothe)
        {
            if (_clothe.GetAllClothe()==null)
            {
                return BadRequest();
            }

         

            try
            {
                _clothe.UpdateClothe(clothe);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_clothe.GetAllClothe()==null)
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
        public ActionResult<Clothe> PostClothe(Clothe clothe)
        {
            if (_clothe.GetAllClothe()== null)
            {
                return Problem("Entity set 'ClotheShopSystemDBContext.Clothes'  is null.");
            }
            _clothe.AddNewClothe(clothe);

            return CreatedAtAction("GetClothe", new { id = clothe.ClotheID }, clothe);
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothe(Guid id)
        {
            if (_clothe.GetAllClothe()==null)
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
