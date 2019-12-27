using System;

namespace MOBoard.Common.Dispatchers
{
    public abstract class IAuthorizedCommand : ICommand
    {
        public Guid UserId { get; set; }
    }


    public abstract class IAuthorizedCommand<T> : ICommand<T>
    {
        public Guid UserId { get; set; }
    }
}