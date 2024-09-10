using ClotheBusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotheDAO.DAOs
{
    public class AccountDAO
    {
        private readonly ClotheShopSystemDBContext _context;
        public AccountDAO()
        {
            _context = new ClotheShopSystemDBContext();
        }

        public Account CheckLogin(string email, string password)
        {
            return _context.Accounts.Where(u => u.Email!.Equals(email) && u.Password!.Equals(password)).FirstOrDefault();
        }



    }
}
