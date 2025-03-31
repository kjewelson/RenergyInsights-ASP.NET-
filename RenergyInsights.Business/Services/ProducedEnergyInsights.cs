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
    public class ProducedEnergyInsights : IProducedEnergyInsights
    {
        private readonly IProducedEnergyRepository _producedEnergyRepository;

        public ProducedEnergyInsights(IProducedEnergyRepository producedEnergyRepository)
        {
            _producedEnergyRepository = producedEnergyRepository;
        }

        public List<string?> GetEnergyProduction()
        {
            return _producedEnergyRepository.GetAllRenergySources();
        }

        public IEnumerable<SourceDetailDto> GetSourceDetails(string selectedSource)
        {
            return _producedEnergyRepository.GetSourceDetails(selectedSource);
        }
    }
}
