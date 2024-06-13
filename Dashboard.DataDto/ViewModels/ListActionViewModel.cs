﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DataDto.ViewModels
{
    public class ListActionViewModel
    {
        public string? FbUser { get; set; }
        public List<byte> ActionName { get; set; } = new List<byte>();
        public bool? Result;
        public List<DateTime> StartTime { get; set; } = new List<DateTime>();
        public List<DateTime> ExcuteTime { get; set; } = new List<DateTime>();
    }
}
