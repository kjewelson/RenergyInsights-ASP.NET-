using RenergyInsights.DTO;
using RenergyInsights.DTO.Respose;

namespace RenergyInsights.Business.IServices
{
    public interface IConsumerInsights
    {

        public List<string?> GetEnergyConsumersAll();
        public ServiceResponse<IEnumerable<ConsumerDetailDto>> GetConsumerDetails(string selectedSource);
    }
}