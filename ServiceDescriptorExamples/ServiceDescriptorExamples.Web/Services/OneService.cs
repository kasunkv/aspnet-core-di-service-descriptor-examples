using ServiceDescriptorExamples.Web.Contracts;

namespace ServiceDescriptorExamples.Web.Services
{
    public class OneService : IOneService
    {
        public string SayOne()
        {
            return "Hello from Service One!!";
        }
    }
}
