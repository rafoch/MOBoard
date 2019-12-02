using System;
using MOBoard.Auth.Users.Write.Domain;
using MOBoard.Common.Types;

namespace MOBoard.Auth.Token.Write.Domain
{
    public class RefreshToken : AggregateRoot
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}