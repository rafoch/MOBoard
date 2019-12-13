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

        public static class Issue
        {
            private const string IssueBase = BaseRoute.Index + "/issue/";
            public const string Create = IssueBase + "create";
            public const string All = IssueBase + "all";
            public const string Assignment = IssueBase + "assignment";
        }
    }
}