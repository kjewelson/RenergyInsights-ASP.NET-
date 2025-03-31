using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RenergyInsights.DAL.DataModels;

namespace RenergyInsights.DAL.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DirectUse> DirectUses { get; set; }

    public virtual DbSet<DirectUsePivot> DirectUsePivots { get; set; }

    public virtual DbSet<PrimaryVsRenewPivot> PrimaryVsRenewPivots { get; set; }

    public virtual DbSet<ProducedEnergy> ProducedEnergies { get; set; }

    public virtual DbSet<ProducedEnergyPivot> ProducedEnergyPivots { get; set; }

    public virtual DbSet<Reallocated> Reallocateds { get; set; }

    public virtual DbSet<ReallocatedPivot> ReallocatedPivots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=D:\\Interview\\HEATLY\\RenergyInsights\\RenergyInsights\\RenergyInsights.DAL\\Data\\data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DirectUse>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DirectUse");

            entity.Property(e => e.DirectUseType).HasColumnName("direct_use_type");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<DirectUsePivot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Direct_UsePivot");

            entity.Property(e => e.AccommodationFoodServices).HasColumnName("accommodation_food_services");
            entity.Property(e => e.AdminSupportServices).HasColumnName("admin_support_services");
            entity.Property(e => e.AgricultureForestryFishing).HasColumnName("agriculture_forestry_fishing");
            entity.Property(e => e.ArtsEntertainmentRecreation).HasColumnName("arts_entertainment_recreation");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.ConsumerExpenditure).HasColumnName("consumer_expenditure");
            entity.Property(e => e.Education).HasColumnName("education");
            entity.Property(e => e.ElectricityGasSupply).HasColumnName("electricity_gas_supply");
            entity.Property(e => e.FinancialInsurance).HasColumnName("financial_insurance#");
            entity.Property(e => e.HealthSocialWork).HasColumnName("health_social_work#");
            entity.Property(e => e.HouseholdActivities).HasColumnName("household_activities");
            entity.Property(e => e.InformationCommunication).HasColumnName("information_communication");
            entity.Property(e => e.Manufacturing).HasColumnName("manufacturing");
            entity.Property(e => e.MiningQuarrying).HasColumnName("mining_quarrying");
            entity.Property(e => e.OtherServices).HasColumnName("other_services");
            entity.Property(e => e.ProfessionalTechnicalServices).HasColumnName("professional_technical_services");
            entity.Property(e => e.PublicAdminDefense).HasColumnName("public_admin_defense");
            entity.Property(e => e.RealEstate).HasColumnName("real_estate");
            entity.Property(e => e.RenewableWasteEnergyUse).HasColumnName("renewable_waste_energy_use");
            entity.Property(e => e.TransportStorage).HasColumnName("transport_storage");
            entity.Property(e => e.WaterWasteManagement).HasColumnName("water_waste_management");
            entity.Property(e => e.WholesaleRetailTrade).HasColumnName("wholesale_retail_trade#");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<PrimaryVsRenewPivot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PrimaryVsRenewPivot");

            entity.Property(e => e.RenewableEnergyPercentag).HasColumnName("renewable_energy_percentag");
            entity.Property(e => e.RenewableWasteEnergy).HasColumnName("renewable_waste_energy");
            entity.Property(e => e.TotalEnergyConsumption).HasColumnName("total_energy_consumption");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<ProducedEnergy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProducedEnergy");

            entity.Property(e => e.SourceType).HasColumnName("source_type");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<ProducedEnergyPivot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProducedEnergyPivot");

            entity.Property(e => e.Biodiesel).HasColumnName("biodiesel");
            entity.Property(e => e.Bioethanol).HasColumnName("bioethanol");
            entity.Property(e => e.BiogasAutogen).HasColumnName("biogas_autogen");
            entity.Property(e => e.Biomass).HasColumnName("biomass");
            entity.Property(e => e.Charcoal).HasColumnName("charcoal");
            entity.Property(e => e.CrossBoundaryAdjustment).HasColumnName("cross_boundary_adjustment");
            entity.Property(e => e.GeothermalAquifers).HasColumnName("geothermal_aquifers");
            entity.Property(e => e.HydroelectricPower).HasColumnName("hydroelectric_power");
            entity.Property(e => e.LandfillGas).HasColumnName("landfill_gas");
            entity.Property(e => e.LiquidBiofuels).HasColumnName("liquid_biofuels");
            entity.Property(e => e.MunicipalSolidWaste).HasColumnName("municipal_solid_waste");
            entity.Property(e => e.PoultryLitter).HasColumnName("poultry_litter");
            entity.Property(e => e.RenewableWasteEnergy).HasColumnName("renewable_waste_energy");
            entity.Property(e => e.SewageGas).HasColumnName("sewage_gas");
            entity.Property(e => e.SolarPhotovoltaic).HasColumnName("solar_photovoltaic");
            entity.Property(e => e.Straw).HasColumnName("straw");
            entity.Property(e => e.WindWaveTidal).HasColumnName("wind_wave_tidal");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.WoodDry).HasColumnName("wood_dry");
            entity.Property(e => e.WoodSeasoned).HasColumnName("wood_seasoned");
            entity.Property(e => e.WoodWet).HasColumnName("wood_wet");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Reallocated>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Reallocated");

            entity.Property(e => e.IndirectUseType).HasColumnName("indirect_use_type");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<ReallocatedPivot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ReallocatedPivot");

            entity.Property(e => e.AccommodationFoodServices).HasColumnName("accommodation_food_services");
            entity.Property(e => e.AdminSupportServices).HasColumnName("admin_support_services");
            entity.Property(e => e.AgricultureForestryFishing).HasColumnName("agriculture_forestry_fishing");
            entity.Property(e => e.ArtsEntertainmentRecreation).HasColumnName("arts_entertainment_recreation");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.ConsumerExpenditure).HasColumnName("consumer_expenditure");
            entity.Property(e => e.Education).HasColumnName("education");
            entity.Property(e => e.ElectricityGasSupply).HasColumnName("electricity_gas_supply");
            entity.Property(e => e.EnergyLossesAllocated).HasColumnName("energy_losses_allocated");
            entity.Property(e => e.FinancialInsurance).HasColumnName("financial_insurance");
            entity.Property(e => e.HealthSocialWork).HasColumnName("health_social_work");
            entity.Property(e => e.HouseholdActivities).HasColumnName("household_activities");
            entity.Property(e => e.InformationCommunication).HasColumnName("information_communication");
            entity.Property(e => e.Manufacturing).HasColumnName("manufacturing");
            entity.Property(e => e.MiningQuarrying).HasColumnName("mining_quarrying");
            entity.Property(e => e.OtherServices).HasColumnName("other_services");
            entity.Property(e => e.ProfessionalTechnicalServices).HasColumnName("professional_technical_services");
            entity.Property(e => e.PublicAdminDefense).HasColumnName("public_admin_defense");
            entity.Property(e => e.RealEstate).HasColumnName("real_estate");
            entity.Property(e => e.RenewableWasteEnergyUse).HasColumnName("renewable_waste_energy_use");
            entity.Property(e => e.TransportStorage).HasColumnName("transport_storage");
            entity.Property(e => e.WaterWasteManagement).HasColumnName("water_waste_management");
            entity.Property(e => e.WholesaleRetailTrade).HasColumnName("wholesale_retail_trade");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
