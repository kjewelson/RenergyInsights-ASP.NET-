using RenergyInsights.DAL.DataModels;
using RenergyInsights.DTO;

namespace RenergyInsights.Models
{
    public class SourceDetailsViewModel
    {
        public string SourceName { get; set; }
        public string Description { get; set; }
        public IEnumerable<SourceDetailDto>? ProductionData { get; set; }


    }
}
