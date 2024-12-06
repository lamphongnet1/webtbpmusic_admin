using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace android.Models;
[Keyless]
public partial class Playlist
{
    public int IdPlaylist { get; set; }

    public int IdTaiKhoan { get; set; }

    public int IdBaiHat { get; set; }

    public string HinhAnhPlaylist { get; set; } = null!;
}
