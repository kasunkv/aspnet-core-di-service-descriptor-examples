using ServiceDescriptorExamples.Web.Contracts;

namespace ServiceDescriptorExamples.Web.Services
{
    public class ThreeService : IThreeService
    {
        public string SayThree()
        {
            return "Hi, Service Three Here..";
        }
    }
}
