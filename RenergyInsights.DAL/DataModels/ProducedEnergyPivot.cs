using System;
using System.Collections.Generic;

namespace RenergyInsights.DAL.DataModels;

public partial class ProducedEnergyPivot
{
    public int? Year { get; set; }

    public double? RenewableWasteEnergy { get; set; }

    public double? HydroelectricPower { get; set; }

    public double? WindWaveTidal { get; set; }

    public double? SolarPhotovoltaic { get; set; }

    public double? GeothermalAquifers { get; set; }

    public double? LandfillGas { get; set; }

    public double? SewageGas { get; set; }

    public double? BiogasAutogen { get; set; }

    public double? MunicipalSolidWaste { get; set; }

    public double? PoultryLitter { get; set; }

    public double? Straw { get; set; }

    public double? Wood { get; set; }

    public double? WoodDry { get; set; }

    public double? WoodSeasoned { get; set; }

    public double? WoodWet { get; set; }

    public double? Charcoal { get; set; }

    public double? LiquidBiofuels { get; set; }

    public double? Bioethanol { get; set; }

    public double? Biodiesel { get; set; }

    public double? Biomass { get; set; }

    public double? CrossBoundaryAdjustment { get; set; }
}
