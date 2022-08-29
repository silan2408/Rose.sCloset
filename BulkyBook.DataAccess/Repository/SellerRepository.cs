using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        private ApplicationDbContext _db;

        public SellerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Seller obj)
        {
            _db.Sellers.Update(obj);
        }
    }
}
