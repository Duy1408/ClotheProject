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
    public class ClotheRepo : IClotheRepo
    {
        ClothesDAO dao = new ClothesDAO();
        public void AddNewClothe(Clothe clothe)
        {
            dao.AddNewClothe(clothe);
        }

        public bool ChangeStatusClothe(Clothe clothe)
        {
            return dao.ChangeStatusClothe(clothe);
        }

        public List<Clothe> GetAllClothe()
        {
            return dao.GetAllClothe();
        }

        public Clothe GetClotheByID(Guid id)
        {
            return dao.GetClotherByID(id);

        }

        public void UpdateClothe(Clothe clothe)
        {
            dao.ChangeStatusClothe(clothe);
        }


    }
}
