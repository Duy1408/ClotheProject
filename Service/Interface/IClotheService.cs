using ClotheBusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IClotheService
    {
        List<Clothe> GetAllClothe();
        void AddNewClothe(Clothe clothe);
        Clothe GetClotheByID(Guid id);
        void UpdateClothe(Clothe clothe);
        bool ChangeStatusClothe(Clothe clothe);
    }
}
