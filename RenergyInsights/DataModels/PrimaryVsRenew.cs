using System;
using System.Collections.Generic;

namespace RenergyInsights.DataModels;

public partial class PrimaryVsRenew
{
    public int? Year { get; set; }

    public double? RenewableWasteEnergy { get; set; }

    public double? TotalEnergyConsumption { get; set; }

    public double? RenewableEnergyPercentag { get; set; }
}
