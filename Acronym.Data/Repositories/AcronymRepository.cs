using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Acronym.Data
{
    public class AcronymRepository : IRepository<Entities.Acronym>
    {
        private readonly MongoCollection<Entities.Acronym> collection;

        public AcronymRepository(MongoDatabase database)
        {
            this.collection = database.GetCollection<Entities.Acronym>("Acronym");
        }

        public Entities.Acronym Find(object id)
        {
            var objectId = new ObjectId(id.ToString());
            return collection.FindOneByIdAs<Entities.Acronym>(objectId);
        }

        public IQueryable<Entities.Acronym> All()
        {
            return collection.AsQueryable();
        }

        public IQueryable<Entities.Acronym> All(Expression<Func<Entities.Acronym, bool>> filter)
        {
            return collection.AsQueryable().Where(filter);
        }

        public void Create(Entities.Acronym response)
        {
            response.Id = ObjectId.GenerateNewId();
            collection.Insert(response);
        }

        public void Update(Entities.Acronym acronym)
        {
            if(acronym.Id == null)
                throw new NullReferenceException("parameter acronym.Id is null");

            collection.Save(acronym);
        }
    }
}
