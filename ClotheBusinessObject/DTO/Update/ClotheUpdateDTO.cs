using ClotheBusinessObject.BusinessObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotheBusinessObject.DTO.Update
{
    public class ClotheUpdateDTO
    {
        public string? ClotheName { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public double? Rent { get; set; }
        public IFormFile? Image { get; set; }
        public bool? Status { get; set; }
    }
}
