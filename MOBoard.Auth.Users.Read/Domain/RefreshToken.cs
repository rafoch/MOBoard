﻿using System;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Users.Read.Domain
{
    public class RefreshToken : AggregateRoot
    {
        public string Token { get; set; } = Guid.NewGuid().ToString();
        public string JwtId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}