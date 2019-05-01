using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceDescriptorExamples.Web.Contracts;
using ServiceDescriptorExamples.Web.Models;

namespace ServiceDescriptorExamples.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOneService _oneService;
        private readonly ITwoService _twoService;
        private readonly IThreeService _threeService;
        private readonly IFourService _fourService;

        public HomeController(IOneService oneService, ITwoService twoService, IThreeService threeService, IFourService fourService)
        {
            _oneService = oneService;
            _twoService = twoService;
            _threeService = threeService;
            _fourService = fourService;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Messages.Add(_oneService.SayOne());
            vm.Messages.Add(_twoService.SayTwo());
            vm.Messages.Add(_threeService.SayThree());
            vm.Messages.Add(_fourService.SayFour());

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
