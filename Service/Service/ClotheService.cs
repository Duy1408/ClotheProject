using ClotheBusinessObject.BusinessObject;
using Repo.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ClotheService : IClotheService

    {
        private readonly IClotheRepo _repo;
        public ClotheService(IClotheRepo repo)
        {
            _repo = repo;
        }
        public void AddNewClothe(Clothe clothe)
        {
            _repo.AddNewClothe(clothe);
        }

        public bool ChangeStatusClothe(Clothe clothe)
        {
            return _repo.ChangeStatusClothe(clothe);
        }

        public List<Clothe> GetAllClothe()
        {
            return _repo.GetAllClothe();
        }

        public Clothe GetClotheByID(Guid id)
        {
            return _repo.GetClotheByID(id);
        }

        public void UpdateClothe(Clothe clothe)
        {
            _repo.ChangeStatusClothe(clothe);
        }
    }
}
