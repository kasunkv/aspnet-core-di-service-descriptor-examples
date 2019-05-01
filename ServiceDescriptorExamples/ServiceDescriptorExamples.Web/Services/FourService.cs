using ServiceDescriptorExamples.Web.Contracts;

namespace ServiceDescriptorExamples.Web.Services
{
    public class FourService : IFourService
    {
        public string SayFour()
        {
            return "I'm Groot";
        }
    }
}
