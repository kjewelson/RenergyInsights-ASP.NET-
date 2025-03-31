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
using Microsoft.EntityFrameworkCore;
using RenergyInsights.Utillities;

namespace RenergyInsights.DAL.Interfaces
{
    public interface IConsumerEnergyRepository
    {

        public List<string?> GetAllRenergyConsumers();

        public IEnumerable<ConsumerDetailDto> GetDirectConsumerDetails(string source);

        public IEnumerable<ConsumerDetailDto> GetReallocatedConsumerDetails(string source);
    }
}
