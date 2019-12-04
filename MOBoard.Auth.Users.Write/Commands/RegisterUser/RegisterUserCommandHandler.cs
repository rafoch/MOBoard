using System.Threading.Tasks;
using JetBrains.Annotations;
using MOBoard.Auth.Users.Write.DataAccess;
using MOBoard.Auth.Users.Write.Domain;
using MOBoard.Common.Dispatchers;

namespace MOBoard.Auth.Users.Write.Commands
{
    [UsedImplicitly]
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly AuthUserWriteContext _context;

        public RegisterUserCommandHandler(AuthUserWriteContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(RegisterUserCommand command)
        {
            var user = new ApplicationUser
            {
                Email = command.Email,
                UserName = command.UserName
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}