using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkChain.Interfaces.Components.Chain
{
    public interface INode : IDisposable, ICloneable
    {
        Guid Id { get; }
        bool IsBeginning { get; }
        bool IsEnd { get; }
        int No { get; }

        void AppendTo(INode parent);
        void Append(INode child);
    }
}
