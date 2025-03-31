using Microsoft.EntityFrameworkCore;
using RenergyInsights.DAL.DataModels;
using RenergyInsights.DTO;
using System.Globalization;
using System.Reflection;

namespace RenergyInsights.DAL.Interfaces
{
    public interface IProducedEnergyRepository : IRepository<ProducedEnergy>
    {

        public List<string?> GetAllRenergySources();

        public IEnumerable<SourceDetailDto> GetSourceDetails(string source);
    }
}