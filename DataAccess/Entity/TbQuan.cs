using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class TbQuan
    {
        public int IdQ { get; set; }
        public int? IdTt { get; set; }
        public string? Tenquan { get; set; }
        public string? Diengiai { get; set; }
        public int? Stt { get; set; }
        public int? NumBan { get; set; }
        public int? NumChothue { get; set; }
        public int? NumCanmua { get; set; }
        public string? Tenquan2 { get; set; }
    }
}
