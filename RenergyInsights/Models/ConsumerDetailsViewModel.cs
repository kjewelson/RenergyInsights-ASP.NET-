using RenergyInsights.DAL.DataModels;
using RenergyInsights.DTO;

namespace RenergyInsights.Models
{
    public class ConsumerDetailsViewModel
    {
        public string ConsumerName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ConsumerDetailDto>? ConsumerData { get; set; }


    }
}
