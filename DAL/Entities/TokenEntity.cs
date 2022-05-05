﻿using System;

namespace TimeSheets.GB.DAL.Entities
{
    public class TokenEntity
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
