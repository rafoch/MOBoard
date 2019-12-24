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
            public const string Edit = IssueBase + "{id}/edit";
            public const string Remove = IssueBase + "{id}/remove";
            public const string Get = IssueBase + "{id}";
        }

        public static class Project
        {
            private const string ProjectBase = BaseRoute.Index + "/project/";
            public const string Create = ProjectBase + "create";
            public const string Get = ProjectBase + "{id}";
            public const string Delete = ProjectBase + "{id}";
            public const string AddPerson = ProjectBase + "{id}/user/add";
            public const string RemovePerson = ProjectBase + "{id}/user/remove/{userId}";
            public const string GetPersons = ProjectBase + "{id}/users";
        }

        public static class User
        {
            private const string UserBase = BaseRoute.Index + "/user/";
            public const string Search = UserBase + "search";
        }
    }
}