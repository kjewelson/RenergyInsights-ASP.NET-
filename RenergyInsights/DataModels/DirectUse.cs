using System;
using System.Collections.Generic;

namespace RenergyInsights.DataModels;

public partial class DirectUse
{
    public int? Year { get; set; }

    public double? RenewableWasteEnergyUse { get; set; }

    public double? AgricultureForestryFishing { get; set; }

    public double? MiningQuarrying { get; set; }

    public double? Manufacturing { get; set; }

    public double? ElectricityGasSupply { get; set; }

    public double? WaterWasteManagement { get; set; }

    public double? Construction { get; set; }

    public double? WholesaleRetailTrade { get; set; }

    public double? TransportStorage { get; set; }

    public double? AccommodationFoodServices { get; set; }

    public double? InformationCommunication { get; set; }

    public double? FinancialInsurance { get; set; }

    public double? RealEstate { get; set; }

    public double? ProfessionalTechnicalServices { get; set; }

    public double? AdminSupportServices { get; set; }

    public double? PublicAdminDefense { get; set; }

    public double? Education { get; set; }

    public double? HealthSocialWork { get; set; }

    public double? ArtsEntertainmentRecreation { get; set; }

    public double? OtherServices { get; set; }

    public int? HouseholdActivities { get; set; }

    public double? ConsumerExpenditure { get; set; }
}
