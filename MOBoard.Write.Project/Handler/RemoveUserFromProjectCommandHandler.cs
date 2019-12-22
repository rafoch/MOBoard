using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Write.Project.Command;
using MOBoard.Write.Project.DataAccess;
using MOBoard.Write.Project.Domain;

namespace MOBoard.Write.Project.Handler
{
    public class RemoveUserFromProjectCommandHandler : ICommandHandler<RemoveUserFromProjectCommand>
    {
        private readonly ProjectWriteContext _projectWriteContext;

        public RemoveUserFromProjectCommandHandler(ProjectWriteContext projectWriteContext)
        {
            _projectWriteContext = projectWriteContext;
        }

        public async Task HandleAsync(RemoveUserFromProjectCommand command)
        {
            var projects = _projectWriteContext.Projects.AsQueryable();
            var isProjectPresent = await projects.AnyAsync(p => p.Id == command.ProjectId && p.RemovedAt == null);
            if (isProjectPresent)
            {
                var project = await projects.FirstOrDefaultAsync(p => p.Id == command.ProjectId);
                var canChangeUsers = project.ProjectPersons.Any(pp =>
                    pp.UserId == command.RequestUserId &&
                    (pp.PermissionType == PermissionType.Admin ||
                     pp.PermissionType == PermissionType.Creator ||
                     pp.PermissionType == PermissionType.Moderator) &&
                    pp.RemovedAt == null);
                var isInProject = project.ProjectPersons.Any(p => p.UserId == command.UserId && p.RemovedAt == null);
                if (isInProject && canChangeUsers)
                {
                    var projectPerson =
                        project.ProjectPersons.FirstOrDefault(pp =>
                            pp.UserId == command.UserId && pp.RemovedAt == null);
                    projectPerson.Remove();
                }

                await _projectWriteContext.SaveChangesAsync();
            }
        }
    }
}