using System;
using System.Collections.Generic;

namespace RenergyInsights.DAL.DataModels;

public partial class Reallocated
{
    public int? Year { get; set; }

    public string? IndirectUseType { get; set; }

    public double? Value { get; set; }
}
