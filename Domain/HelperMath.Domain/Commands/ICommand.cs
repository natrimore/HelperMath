using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelperMath.Domain.Commands
{
    public interface ICommand
    {
        bool Contains(string messageName);
        Task Execute();
    }
}
