using System;

namespace Acronym.Domain
{
    public class SubmitAcronymResponse : ICommand
    {
        public string Id { get; set; }
        public string[] Words { get; set; }
        public object AcronymId { get; set; }
    }
}