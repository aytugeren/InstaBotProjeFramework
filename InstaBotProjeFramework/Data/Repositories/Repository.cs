using InstaBotProjeFramework.Data.DbContextFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InstaBotProjeFramework.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        InstaBotContext instaBot = new InstaBotContext();

        DbSet<T> _object;
        public Repository()
        {
            _object = instaBot.Set<T>();
        }
        

        public int Delete(T p)
        {
            _object.Remove(p);
            return instaBot.SaveChanges();
        }

        public T GetById(Guid id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return instaBot.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            instaBot.Entry(p).State = EntityState.Modified;
            return instaBot.SaveChanges();
        }
    }
}