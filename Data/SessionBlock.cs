﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace YourTimeApp.Data
{
    public class SessionBlock
    {
        public int Id { get; set; }
        public TimeSpan TimeAlloc { get; set; }
        public SessionTimer Timer { get; set; }
        public Dictionary<ToDo, TimeSpan?> ToDos { get; set; } = [];

    }
}
