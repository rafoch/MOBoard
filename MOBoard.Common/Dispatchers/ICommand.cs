using System;
using Microsoft.AspNetCore.Http;

namespace MOBoard.Common.Dispatchers
{
    public interface ICommand
    {
    }

    public interface ICommand<T> : ICommand
    {
    }
}