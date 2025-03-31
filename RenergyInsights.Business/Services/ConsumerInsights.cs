using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenergyInsights.Business.IServices;
using RenergyInsights.DAL.DataModels;
using RenergyInsights.DAL.Interfaces;
using RenergyInsights.DTO;

namespace RenergyInsights.Business.Services
{
    public class ConsumerInsights : IConsumerInsights
    {
        private readonly IConsumerEnergyRepository _consumerEnergyRepository;

        public ConsumerInsights(IConsumerEnergyRepository consumerEnergyRepository)
        {
            _consumerEnergyRepository = consumerEnergyRepository;
        }

        public List<string?> GetEnergyConsumersAll()
        {
            return _consumerEnergyRepository.GetAllRenergyConsumers();
        }

        public IEnumerable<ConsumerDetailDto> GetConsumerDetails(string selectedSource)
        {
            return _consumerEnergyRepository.GetbothConsumerDetails(selectedSource);
        }
    }
}
