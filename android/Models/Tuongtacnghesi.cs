using System;
using System.Collections.Generic;

namespace android.Models;

public partial class Tuongtacnghesi
{
    public int IdTuongTacNs { get; set; }

    public int IdTaiKhoan { get; set; }

    public int IdNgheSi { get; set; }

    public string LoaiTuongTac { get; set; } = null!;
}
