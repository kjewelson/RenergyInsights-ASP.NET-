using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RenergyInsights.Business.IServices;
using RenergyInsights.DAL.DataModels;
using RenergyInsights.Models;

namespace RenergyInsights.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProducedEnergyInsights _producedEnergyInsights;
        private readonly IConsumerInsights _consumerInsights; 

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger
        , IProducedEnergyInsights producedEnergyInsights
        , IConfiguration configuration
        , IConsumerInsights consumerInsights)
        {
            _logger = logger;
            _producedEnergyInsights = producedEnergyInsights;
            _configuration = configuration;
            _consumerInsights = consumerInsights;
        }

        public IActionResult Index()
        {
            //var result  = _producedEnergyInsights.GetEnergyProduction();
            return View();
        }

        public IActionResult Production(string selectedSource = "hydroelectric_power")
        {
            var result = _producedEnergyInsights.GetEnergyProduction();


            if (!string.IsNullOrEmpty(selectedSource))
            {
                ViewBag.SelectedSource = selectedSource;
                ViewBag.SourceDetails = new SourceDetailsViewModel
                {
                    SourceName = selectedSource,
                    Description = "Here it comes the desciption about the source" , // Your method
                    ProductionData = _producedEnergyInsights.GetSourceDetails(selectedSource)  // Your method
                };
            }

            return View(result);
        }

        public IActionResult Consumption(string selectedConsumer = null)
        {
            var result = _consumerInsights.GetEnergyConsumersAll();


            if (!string.IsNullOrEmpty(selectedConsumer))
            {
                ViewBag.SelectedConsumer = selectedConsumer;
                ViewBag.ConsumerDetails = new ConsumerDetailsViewModel
                {
                    ConsumerName = selectedConsumer,
                    Description = "Here it comes the desciption about the source", // Your method
                    ConsumerData = _consumerInsights.GetConsumerDetails(selectedConsumer)  // Your method
                };
            }

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new /*ErrorViewModel*/ { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
