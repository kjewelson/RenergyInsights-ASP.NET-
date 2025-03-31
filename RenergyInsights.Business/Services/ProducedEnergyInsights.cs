using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenergyInsights.Business.IServices;
using RenergyInsights.DAL.DataModels;
using RenergyInsights.DAL.Interfaces;
using RenergyInsights.DTO;
using RenergyInsights.DTO.Respose;

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

        public ServiceResponse<IEnumerable<SourceDetailDto>> GetSourceDetails(string selectedSource)
        {
            //var response = new ServiceResponse<IEnumerable<SourceDetailDto>>();

            try
            {
                var data = _producedEnergyRepository.GetSourceDetails(selectedSource);

                if (data == null || !data.Any())
                {
                    return ServiceResponse<IEnumerable<SourceDetailDto>>.Failure(
                        false,
                        null,
                        "Error Occurred while processing the request",
                        new Dictionary<string, string> { { "DataNotFound", "No records found" } });
                }

                return ServiceResponse<IEnumerable<SourceDetailDto>>.Success(
                    true,
                    data,
                    "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<SourceDetailDto>>.Failure(
                    false,
                    null,
                    "Error Occurred while processing the request",
                    new Dictionary<string, string> { { "SystemError", ex.Message } });
            }
        }
    }
}
