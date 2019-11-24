using WorkChain.Enums;
using WorkChain.Interfaces.Context;

namespace WorkChain.Interfaces.Rules.ChainNode
{
    public interface IOutput
    {
        OPTStatus Output(IChainContext context);
    }
}
