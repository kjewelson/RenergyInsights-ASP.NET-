using RenergyInsights.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenergyInsights.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DirectUse> DirectUses { get; }
        IRepository<DirectUsePivot> DirectUsePivots { get; }
        IRepository<PrimaryVsRenewPivot> PrimaryVsRenewPivots { get; }
        IRepository<ProducedEnergy> ProducedEnergies { get; }
        IRepository<ProducedEnergyPivot> ProducedEnergyPivots { get; }
        IRepository<Reallocated> Reallocateds { get; }
        IRepository<ReallocatedPivot> ReallocatedPivots { get; }

        Task<int> CompleteAsync();
    }
}
