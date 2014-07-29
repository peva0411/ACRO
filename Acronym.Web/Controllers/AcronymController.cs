using System;
using System.Collections.Generic;
using System.Web.Http;
using Acronym.Domain;
using Acronym.Web.Models;
using AutoMapper;

namespace Acronym.Web.Controllers
{
    public class AcronymController : EntityController<Data.Entities.Acronym>
    {
        // GET api/Acronym
        public IEnumerable<AcronymViewModel> Get()
        {
            return Mapper.Map<IEnumerable<AcronymViewModel>>(repository.All());
        }

        // GET api/Acronym/5
        public AcronymViewModel Get(string id)
        {
            return Mapper.Map<AcronymViewModel>(repository.Find(id));
        }

        // POST api/Acronym
        public void Post([FromBody]CreateAcronym value)
        {
            var handler = new AcronymHandler(repository);
            handler.Handle(value);
        }

        // PUT api/Acronym/5
        public void Put(string id, [FromBody]SubmitAcronymResponse value)
        {
            var handler = new AcronymHandler(repository);
            handler.Handle(value);
        }

        // DELETE api/Acronym/5
        public void Delete(string id)
        {
        }
    }
}
