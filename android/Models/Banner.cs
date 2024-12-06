using System;
using System.Collections.Generic;

namespace android.Models;

public partial class Banner
{
    public int IdBanner { get; set; }

    public string HinhAnhBanner { get; set; } = null!;

    public int IdBaiHat { get; set; }

    public string NoiDung { get; set; } = null!;
}
