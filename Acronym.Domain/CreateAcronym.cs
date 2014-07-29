namespace Acronym.Domain
{
    public class CreateAcronym : ICommand
    {
        public string Id { get; set; }
        public string Acronym { get; set; }
    }
}