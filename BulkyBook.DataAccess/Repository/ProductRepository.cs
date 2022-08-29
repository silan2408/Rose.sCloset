using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Stock = obj.Stock;
                objFromDb.Image = obj.Image;

                objFromDb.UnitPrice = obj.UnitPrice;
                objFromDb.ProductName = obj.ProductName;
                objFromDb.Discount = obj.Discount;

                objFromDb.Category_Id = obj.Category_Id;
                objFromDb.Company_Id = obj.Company_Id;

                objFromDb.Description = obj.Description;
                if (obj.Image != null)
                {
                    objFromDb.Image = obj.Image;
                }
            }
        }
    }
}
