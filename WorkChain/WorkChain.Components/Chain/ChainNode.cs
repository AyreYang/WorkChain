using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkChain.Components.Chain.Base;

namespace WorkChain.Components.Chain
{
    internal class ChainNode : Node
    {
        public ChainNode(Guid id) : base(id)
        {
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        protected override void DisposeData()
        {
            throw new NotImplementedException();
        }
    }
}
