namespace MOBoard.Common.Services
{
    public static class ProjectAliasAndNumberingService
    {
        public static string GetProjectNumber(string projectAlias, int issueNumber)
        {
            return projectAlias + "-" + issueNumber;
        }

        public static int GenerateNextIssueNumber(int lastIssueNumber)
        {
            return ++lastIssueNumber;
        }
    }
}