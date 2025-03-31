using RenergyInsights.DAL.Repositories;
using RenergyInsights.DTO;
using RenergyInsights.DTO.Respose;

namespace RenergyInsights.Business.IServices
{
    public interface IProducedEnergyInsights
    {

        public List<string?> GetEnergyProduction();

        public ServiceResponse<IEnumerable<SourceDetailDto>> GetSourceDetails(string selectedSource);
    }
}