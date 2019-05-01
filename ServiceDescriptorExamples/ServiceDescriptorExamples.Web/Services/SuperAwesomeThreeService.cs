using ServiceDescriptorExamples.Web.Contracts;

namespace ServiceDescriptorExamples.Web.Services
{
    public class SuperAwesomeThreeService : IThreeService
    {
        public string SayThree()
        {
            return "Hi, Super Awesome Service Three Here..";
        }
    }
}
