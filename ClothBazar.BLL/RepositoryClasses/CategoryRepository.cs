using ClothBazar.BLL.IRepositories;
using ClothBazar.DAL2;
using ClothBazar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.BLL.RepositoryClasses
{
    public class CategoryRepository : ICategoryRepository
    {
        CBContext db;
        public CategoryRepository()
        {
            db = new CBContext();
        }
        public void Delete(Category entity)
        {
            db.Categories.Remove(entity);
            SaveChanges();
        }

        public IQueryable<Category> FindBy(Expression<Func<Category, bool>> predicate)
        {
            return db.Categories.Where(predicate);
        }

        public Category Get(int ID)
        {
            return db.Categories.SingleOrDefault(a => a.ID == ID);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public void Insert(Category entity)
        {
            db.Categories.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Category entity)
        {
            var old = Get(entity.ID);
            old.Name = entity.Name;
            old.Description = entity.Description;
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
