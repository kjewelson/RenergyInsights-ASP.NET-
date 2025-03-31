using System;
using System.Collections.Generic;

namespace RenergyInsights.DAL.DataModels;

public partial class DirectUse
{
    public int? Year { get; set; }

    public string? DirectUseType { get; set; }

    public double? Value { get; set; }
}
