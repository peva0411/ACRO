using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Acronym.Data
{
    public class DataContext
    {
        private readonly Dictionary<Type, IRepository> repositories;

        public DataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Mongo"].ConnectionString;
            
            var database = new MongoClient(connectionString)
                .GetServer()
                .GetDatabase("Acronym");

            repositories = new Dictionary<Type, IRepository>();
            Register(new AcronymRepository(database));
        }

        private void Register<T>(IRepository<T> repository) where T : IEntity
        {
            repositories.Add(typeof(T), repository);
        }

        public IRepository<T> GetRepository<T>() where T : IEntity
        {
            return (IRepository<T>)repositories[typeof (T)];
        }
    }
}
