using System;
using System.Collections.Generic;

namespace RenergyInsights.DAL.DataModels;

public partial class ProducedEnergy
{
    public int? Year { get; set; }

    public string? SourceType { get; set; }

    public double? Value { get; set; }
}
