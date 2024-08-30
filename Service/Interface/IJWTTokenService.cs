using ClotheBusinessObject.BusinessObject;
using ClotheBusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IJWTTokenService
    {
        string CreateJWTToken(Account account);
        AuthVM ParseJwtToken(string token);

    }
}
