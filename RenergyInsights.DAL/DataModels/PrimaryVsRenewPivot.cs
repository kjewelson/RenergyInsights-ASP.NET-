using System;
using System.Collections.Generic;

namespace RenergyInsights.DAL.DataModels;

public partial class PrimaryVsRenewPivot
{
    public int? Year { get; set; }

    public double? RenewableWasteEnergy { get; set; }

    public double? TotalEnergyConsumption { get; set; }

    public double? RenewableEnergyPercentag { get; set; }
}
