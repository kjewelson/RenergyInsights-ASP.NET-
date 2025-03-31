using RenergyInsights.DTO;

namespace RenergyInsights.Business.IServices
{
    public interface IConsumerInsights
    {

        public List<string?> GetEnergyConsumersAll();
        public IEnumerable<ConsumerDetailDto> GetConsumerDetails(string selectedSource);
    }
}