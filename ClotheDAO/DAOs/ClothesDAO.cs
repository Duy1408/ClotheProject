using ClotheBusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotheDAO.DAOs
{
    public class ClothesDAO
    {
        private readonly ClotheShopSystemDBContext _context;
        public ClothesDAO()
        {
            _context = new ClotheShopSystemDBContext();
        }

        public List<Clothe> GetAllClothe()
        {
            try
            {
                return _context.Clothes!.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewClothe(Clothe clothe)
        {
            try
            {
                _context.Add(clothe);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Clothe GetClotherByID(Guid id)
        {
            try
            {
                var clothe = _context.Clothes!.SingleOrDefault(c => c.ClotheID == id);
                return clothe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeStatusClothe(Clothe clothe)
        {
            var _clothe = _context.Clothes.FirstOrDefault(c => c.ClotheID.Equals(clothe.ClotheID));


            if (_clothe == null)
            {
                return false;
            }
            else
            {
                _clothe.Status = false;
                _context.Entry(_clothe).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
