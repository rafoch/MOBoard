using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Dispatchers;
using MOBoard.Write.Project.Command;
using MOBoard.Write.Project.DataAccess;

namespace MOBoard.Write.Project.Handler
{
    [UsedImplicitly]
    public class DeleteProjectByIdCommandHandler : ICommandHandler<DeleteProjectByIdCommand>
    {
        private readonly ProjectWriteContext _context;

        public DeleteProjectByIdCommandHandler(ProjectWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(DeleteProjectByIdCommand command)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == command.Id && p.RemovedAt == null);
            if (project != null)
            {
                project.Remove();
                await _context.SaveChangesAsync();
            }
        }
    }
}