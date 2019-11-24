using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkChain.Interfaces.Components.Chain;

namespace WorkChain.Components.Chain.Base
{
    internal abstract class Node : INode
    {
        public Guid Id { get; private set; }
        protected INode ParentNode { get; private set; }
        public bool IsBeginning
        {
            get
            {
                return ParentNode == null;
            }
        }
        protected INode ChildNode { get; private set; }
        public bool IsEnd
        {
            get
            {
                return ChildNode == null;
            }
        }
        public int No
        {
            get
            {
                return (ParentNode != null ? ParentNode.No : 0) + 1;
            }
        }


        public Node(Guid id)
        {
            if (Guid.Empty.Equals(id)) throw new ArgumentException("The node id is empty!", "id");
            Id = id;
            ParentNode = null;
            ChildNode = null;
        }

        public void AppendTo(INode parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            ParentNode = parent;
        }

        public void Append(INode child)
        {
            if (child == null) throw new ArgumentNullException("child");
            child.AppendTo(this);
            ChildNode = child;
        }

        public void Dispose()
        {
            if (ChildNode != null) ChildNode.Dispose();
            try
            {
                DisposeData();
            }
            catch { }
        }

        protected abstract void DisposeData();
        public abstract object Clone();
    }
}
