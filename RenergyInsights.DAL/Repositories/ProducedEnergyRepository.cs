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
using RenergyInsights.Utillities;

namespace RenergyInsights.DAL.Repositories
{
    public class ProducedEnergyRepository : Repository<ProducedEnergy>, IProducedEnergyRepository
    {

        private readonly ApplicationDbContext _context;

        public ProducedEnergyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<string?> GetAllRenergySources()
        {
            return _context.ProducedEnergies.Select(e => e.SourceType).Distinct().ToList();
        }

        public IEnumerable<SourceDetailDto> GetSourceDetails(string source)
        {
            var propertyInfo = UtilPractice.GetPropertyInfo(source, new ProducedEnergyPivot().GetType());

            return _context.ProducedEnergyPivots
                .AsEnumerable()
                .Select(e => new SourceDetailDto
                {
                    Value = (double)propertyInfo.GetValue(e),
                    RenewableWasteEnergy = e.RenewableWasteEnergy,
                    Year = e.Year
                }).OrderByDescending(e => e.Year);
        }


    }
}
