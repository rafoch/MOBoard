using MOBoard.Common.Contractors.V1.OAuth;
using Swashbuckle.AspNetCore.Filters;

namespace MOBoard.Web.ContractorsFilters.V1.Auth
{
    public class AuthLoginRequestExample : IExamplesProvider<LoginRequest>
    {
        public LoginRequest GetExamples()
        {
            return new LoginRequest
            {
                Username = "zaq1@WSX",
                Password = "zaq1@WSX"
            };
        }
    }
}