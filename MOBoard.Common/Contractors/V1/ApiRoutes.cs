namespace MOBoard.Common.Contractors.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class BaseRoute
        {
            public const string Index = Base;
        }

        public static class Authorization
        {
            private const string AuthBase = BaseRoute.Index + "/oauth/";
            public const string Login = AuthBase + "login";
            public const string Register = AuthBase + "register";
        }
    }
}