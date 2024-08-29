using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotheBusinessObject.BusinessObject
{
    public class Shop
    {
        public Guid ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Clothe> Clothes { get; set; }





    }
}
