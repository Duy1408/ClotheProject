using ClotheBusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotheBusinessObject.ViewModel
{
    public class ClotheVM
    {
        public Guid ClotheID { get; set; }
        public string ClotheName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Rent { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }


    }
}
