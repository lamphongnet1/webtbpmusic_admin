using System;
using System.Collections.Generic;

namespace android.Models;

public partial class Taikhoan
{
    public int IdTaiKhoan { get; set; }

    public string Ten { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string VaiTro { get; set; } = null!;
}
