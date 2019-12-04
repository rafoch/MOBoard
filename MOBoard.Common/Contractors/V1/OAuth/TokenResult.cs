namespace MOBoard.Common.Contractors.V1.OAuth
{
    public class TokenResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
    }
}