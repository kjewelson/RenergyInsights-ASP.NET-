using RenergyInsights.DAL.Data;
using RenergyInsights.DAL.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RenergyInsights.DTO;
using RenergyInsights.DAL.Interfaces;

namespace RenergyInsights.DAL.Repositories
{
    public class ProducedEnergyRepository : IProducedEnergyRepository
    {

        private readonly ApplicationDbContext _context;

        public ProducedEnergyRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<string?> GetAllRenergySources()
        {
            return _context.ProducedEnergies.Select(e => e.SourceType).Distinct().ToList();
        }

        public IEnumerable<SourceDetailDto> GetSourceDetails(string source)
        {
            string pascalCaseProperty = CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(source.Replace("_", " ").ToLower())
                .Replace(" ", "");

            PropertyInfo property = typeof(ProducedEnergyPivot).GetProperty(pascalCaseProperty);

            if (property == null)
            {
                throw new ArgumentException($"Invalid source: {source}");
            }

            return _context.ProducedEnergyPivots
                .AsEnumerable()
                .Select(e => new SourceDetailDto
                {
                    Value = (double)property.GetValue(e),
                    RenewableWasteEnergy = e.RenewableWasteEnergy,
                    Year = e.Year
                }).OrderByDescending(e => e.Year);
        }


    }
}
