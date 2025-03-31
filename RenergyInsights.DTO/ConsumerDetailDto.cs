using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenergyInsights.DTO
{
    public class ConsumerDetailDto
    {
        public double DirectValue { get; set; }
        public double ReallocatedValue { get; set; }
        public object RenewableWasteEnergy { get; set; }
        public int? Year { get; set; }
    }
}
