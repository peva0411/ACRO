using Acronym.Data;
using Acronym.Data.Entities;

namespace Acronym.Domain
{
    public class AcronymHandler : 
        ICommandHandler<SubmitAcronymResponse>, 
        ICommandHandler<CreateAcronym>
    {
        private readonly IRepository<Data.Entities.Acronym> repository;

        public AcronymHandler(IRepository<Data.Entities.Acronym> repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateAcronym command)
        {
            var acronym = new Data.Entities.Acronym { AcronymText = command.Acronym };
            repository.Create(acronym);
            command.Id = acronym.Id.ToString();
        }

        public void Handle(SubmitAcronymResponse command)
        {
            var acronymResponse = new AcronymResponse { Words = command.Words };
            var acronym = repository.Find(command.AcronymId);
            acronym.Responses.Add(acronymResponse);
            repository.Update(acronym);
            command.Id = acronymResponse.Id.ToString();
        }
    }
}