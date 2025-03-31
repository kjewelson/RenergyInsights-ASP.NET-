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

        public ServiceResponse<IEnumerable<ConsumerDetailDto>> GetConsumerDetails(string selectedSource)
        {
            var response = new ServiceResponse<IEnumerable<ConsumerDetailDto>>();

            try
            {
                // Get data from repositories
                var direct = _consumerEnergyRepository.GetDirectConsumerDetails(selectedSource);
                var reallocated = _consumerEnergyRepository.GetReallocatedConsumerDetails(selectedSource);

                // Validate data
                if (direct == null || reallocated == null)
                {
                    response.Error.Add("DataError", "Failed to retrieve consumer data");
                    return ServiceResponse<IEnumerable<ConsumerDetailDto>>.Failure(
                        status: false,
                        data: null,
                        message: "Data retrieval failed",
                        error: response.Error);
                }

                // Process the data
                var result = direct.Join(reallocated
                    , d => d.Year
                    , r => r.Year
                    , (d, r) => new ConsumerDetailDto
                    {
                        Year = d.Year,
                        DirectValue = d.DirectValue,
                        ReallocatedValue = r.ReallocatedValue,
                        RenewableWasteEnergy = d.RenewableWasteEnergy
                    })
                    .OrderByDescending(d => d.Year);

                return ServiceResponse<IEnumerable<ConsumerDetailDto>>.Success(
                    true,
                    result,
                    "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                response.Error.Add("SystemError", ex.Message);
                return ServiceResponse<IEnumerable<ConsumerDetailDto>>.Failure(
                    false,
                    null,
                    "An error occurred while processing your request",
                    response.Error);
            }
        }
    }
}
