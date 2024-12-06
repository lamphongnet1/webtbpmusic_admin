using System;
using System.Collections.Generic;

namespace android.Models;

public partial class Baihat
{
    public int IdBaiHat { get; set; }

    public int IdDanhMuc { get; set; }

    public string TenBaiHat { get; set; } = null!;

    public DateOnly NgayPhatHanh { get; set; }

    public string HinhBaiHat { get; set; } = null!;

    public string LinkBaiHat { get; set; } = null!;

    public int IdNgheSi { get; set; }
}
