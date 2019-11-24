using System;
using WorkChain.Interfaces.Context;

namespace WorkChain.Interfaces.Rules.ChainNode
{
    public interface IInput
    {
        Guid[] Input(IChainContext context);
    }
}
