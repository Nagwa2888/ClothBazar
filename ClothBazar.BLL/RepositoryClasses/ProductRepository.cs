using ClothBazar.BLL.IRepositories;
using ClothBazar.DAL2;
using ClothBazar.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.BLL.RepositoryClasses
{
    class ProductRepository : IProductRepository
    {
        CBContext db;
        public ProductRepository()
        {
            db = new CBContext();
        }
        public void Delete(Product entity)
        {
            db.Products.Remove(entity);
            SaveChanges();
        }

        public IQueryable<Product> FindBy(Expression<Func<Product, bool>> predicate)
        {
            return db.Products.Where(predicate);
        }

        public Product Get(int ID)
        {
            return db.Products.SingleOrDefault(a => a.ID == ID);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public void Insert(Product entity)
        {
            db.Products.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Product entity)
        {
            var old = Get(entity.ID);
            old.Name = entity.Name;
            old.Price = entity.Price;
            old.Description = entity.Description;
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
