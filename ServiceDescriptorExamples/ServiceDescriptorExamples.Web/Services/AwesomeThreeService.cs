using ServiceDescriptorExamples.Web.Contracts;

namespace ServiceDescriptorExamples.Web.Services
{
    public class AwesomeThreeService : IThreeService
    {
        public string SayThree()
        {
            return "Hi, Awesome Service Three Here..";
        }
    }
}
