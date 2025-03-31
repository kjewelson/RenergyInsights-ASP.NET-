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
    public class ConsumerEnergyRepository : IConsumerEnergyRepository
    {

        private readonly ApplicationDbContext _context;

        public ConsumerEnergyRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<string?> GetAllRenergyConsumers()
        {
            return _context.DirectUses
                .Where(e=>e.Value>0)
                .Select(e => e.DirectUseType)
                .Distinct()
                .ToList();
        }

        public IEnumerable<ConsumerDetailDto> GetbothConsumerDetails(string source)
        {
            string pascalCaseProperty = CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(source.Replace("_", " ").Replace("#","").ToLower())
                .Replace(" ", "");

            PropertyInfo reallocProperty = typeof(ReallocatedPivot).GetProperty(pascalCaseProperty);
            PropertyInfo directProperty = typeof(DirectUsePivot).GetProperty(pascalCaseProperty);

            if (reallocProperty == null || directProperty == null)
            {
                throw new ArgumentException($"Invalid source: {source}");
            }

            var direct =  _context.DirectUsePivots
                .AsEnumerable()
                .Select(e => new ConsumerDetailDto
                {
                    DirectValue = (double)directProperty.GetValue(e), //from DirectUsePivot
                    RenewableWasteEnergy = e.RenewableWasteEnergyUse,
                    Year = e.Year
                }).OrderByDescending(e => e.Year);


            var reallocated = _context.ReallocatedPivots
                .AsEnumerable()
                .Select(e => new ConsumerDetailDto
                {
                    ReallocatedValue = (double)reallocProperty.GetValue(e), //from DirectUsePivot
                    RenewableWasteEnergy = e.RenewableWasteEnergyUse,
                    Year = e.Year
                }).OrderByDescending(e => e.Year);


            
            var result  =  direct.Join(reallocated
                ,d=>d.Year
                ,r=>r.Year
                ,(d,r) => new ConsumerDetailDto
                {
                    Year = d.Year,
                    DirectValue = d.DirectValue,
                    ReallocatedValue=r.ReallocatedValue,
                    RenewableWasteEnergy = d.RenewableWasteEnergy
                }
                ).OrderByDescending(d => d.Year);

            return result;
        
        }


    }
}
