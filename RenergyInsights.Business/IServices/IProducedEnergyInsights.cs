using RenergyInsights.DAL.Repositories;
using RenergyInsights.DTO;

namespace RenergyInsights.Business.IServices
{
    public interface IProducedEnergyInsights
    {

        public List<string?> GetEnergyProduction();

        public IEnumerable<SourceDetailDto> GetSourceDetails(string selectedSource);
    }
}