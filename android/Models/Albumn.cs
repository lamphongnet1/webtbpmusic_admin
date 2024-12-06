using System;
using System.Collections.Generic;

namespace android.Models;

public partial class Albumn
{
    public int IdAlbumn { get; set; }

    public int IdNgheSi { get; set; }

    public int IdBaiHat { get; set; }

    public string TenAlbumn { get; set; } = null!;

    public DateOnly NgaoTao { get; set; }
}
