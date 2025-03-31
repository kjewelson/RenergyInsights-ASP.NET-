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
using RenergyInsights.DTO.Respose;

namespace RenergyInsights.DAL.Repositories
{
    public class DirectUseRepository : Repository<DirectUse>, IConsumerEnergyRepository
    {

        private readonly ApplicationDbContext _context;

        public DirectUseRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public List<string?> GetAllRenergyConsumers()
        {
            return _context.DirectUses
                .Where(e=>e.Value>0)
                .Select(e => e.DirectUseType)
                .Distinct()
                .ToList();
        }

        public IEnumerable<ConsumerDetailDto> GetDirectConsumerDetails(string source)
        {

            var propertyInfo = UtilPractice.GetPropertyInfo(source, new DirectUsePivot().GetType());

            var direct = _context.DirectUsePivots
                .AsEnumerable()
                .Select(e => new ConsumerDetailDto
                {
                    DirectValue = (double)propertyInfo.GetValue(e), //from DirectUsePivot
                    RenewableWasteEnergy = e.RenewableWasteEnergyUse,
                    Year = e.Year
                }).OrderByDescending(e => e.Year);


            return direct;
        }

        public IEnumerable<ConsumerDetailDto> GetReallocatedConsumerDetails(string source)
        {


            var ReallocatedPropertyInfo = UtilPractice.GetPropertyInfo(source, new ReallocatedPivot().GetType());

            
            var reallocated = _context.ReallocatedPivots
                .AsEnumerable()
                .Select(e => new ConsumerDetailDto
                {
                    ReallocatedValue = (double)ReallocatedPropertyInfo.GetValue(e), //from DirectUsePivot
                    RenewableWasteEnergy = e.RenewableWasteEnergyUse,
                    Year = e.Year
                }).OrderByDescending(e => e.Year);



            return reallocated;

        }


    }
}
