using ClotheBusinessObject.BusinessObject;
using ClotheDAO.DAOs;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository
{
    public class AccountRepo : IAccountRepo
    {
        AccountDAO dao = new AccountDAO();

        public Account CheckLogin(string email, string password) => dao.CheckLogin(email, password);

    }
}
