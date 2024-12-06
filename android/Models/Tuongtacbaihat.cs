using System;
using System.Collections.Generic;

namespace android.Models;

public partial class Tuongtacbaihat
{
    public int IdTuongTac { get; set; }

    public int IdTaiKhoan { get; set; }

    public string IdBaiHat { get; set; } = null!;

    public string LoaiTuongTac { get; set; } = null!;
}
