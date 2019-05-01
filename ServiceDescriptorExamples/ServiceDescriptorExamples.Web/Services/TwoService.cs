using ServiceDescriptorExamples.Web.Contracts;

namespace ServiceDescriptorExamples.Web.Services
{
    public class TwoService : ITwoService
    {
        public string SayTwo()
        {
            return "Wassup! I'm Service Two";
        }
    }
}
