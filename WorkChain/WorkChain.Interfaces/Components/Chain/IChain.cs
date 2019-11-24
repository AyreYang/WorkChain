using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkChain.Interfaces.Components.Chain
{
    public interface IChain : IDisposable, ICloneable
    {
        Guid Id { get; }
        bool IsBeginning { get; }
        bool IsEnd { get; }
        int No { get; }

        INode TheBeginningNode { get; }

        void AppendTo(IChain parent);
        void Append(IChain child);
    }
}
