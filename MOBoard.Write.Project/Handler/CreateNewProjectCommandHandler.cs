using System.Threading.Tasks;
using JetBrains.Annotations;
using MOBoard.Common.Dispatchers;
using MOBoard.Write.Project.Command;
using MOBoard.Write.Project.DataAccess;

namespace MOBoard.Write.Project.Handler
{
    [UsedImplicitly]
    public class CreateNewProjectCommandHandler : ICommandHandler<CreateNewProjectCommand>
    {
        private readonly ProjectWriteContext _projectWriteContext;

        public CreateNewProjectCommandHandler(ProjectWriteContext projectWriteContext)
        {
            _projectWriteContext = projectWriteContext;
        }
        public async Task HandleAsync(CreateNewProjectCommand command)
        {
            _projectWriteContext.Projects.Add(new Domain.Project(command.Name, command.Description, command.Alias,
                command.CreatorId));
            await _projectWriteContext.SaveChangesAsync();
        }
    }
}