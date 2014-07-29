using System.Collections.Generic;

namespace Acronym.Data.Entities
{
    public class Acronym : IEntity
    {
        public Acronym()
        {
            Responses = new List<AcronymResponse>();
        }

        public object Id { get; set; }
        public string AcronymText { get; set; }
        public ICollection<AcronymResponse> Responses { get; set; }
    }
}