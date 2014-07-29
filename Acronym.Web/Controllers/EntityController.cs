using System.Web.Http;
using System.Web.Http.Controllers;
using Acronym.Data;

namespace Acronym.Web.Controllers
{
    public class EntityController<TEntity> : ApiController where TEntity : IEntity
    {
        protected IRepository<TEntity> repository;
 
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new DataContext();
            repository = context.GetRepository<TEntity>();
        }
    }
}