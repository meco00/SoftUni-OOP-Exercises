using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public  class Repository<T> : IRepository<T>
    {
        private ICollection<T> Models;

        public Repository()
        {
            this.Models = new List<T>();
        }

        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models.ToList().AsReadOnly();
        }

        public T GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool Remove(T model)
        {
            return this.Models.Remove(model);
        }
    }
}
