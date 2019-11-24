using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkChain.Interfaces.Components.Chain;

namespace WorkChain.Components.Chain.Base
{
    internal abstract class Chain : IChain
    {
        public Guid Id { get; private set; }
        protected IChain Parent { get; private set; }
        public bool IsBeginning
        {
            get
            {
                return Parent == null;
            }
        }
        protected IList<IChain> Children { get; private set; }
        public bool IsEnd
        {
            get
            {
                return Children.Count == 0;
            }
        }

        public int No
        {
            get
            {
                return (Parent != null ? Parent.No : 0) + 1;
            }
        }

        private INode _node { get; set; }
        public INode TheBeginningNode
        {
            get
            {
                return _node;
            }
        }

        public Chain(Guid id, INode node)
        {
            if (Guid.Empty.Equals(id)) throw new ArgumentException("The chain id is empty!", "id");
            if (node == null) throw new ArgumentNullException("node");

            Id = id;
            _node = node;
            Parent = null;
            Children = new List<IChain>();
        }

        public void AppendTo(IChain parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            Parent = parent;
        }

        public void Append(IChain child)
        {
            if (child == null) throw new ArgumentNullException("child");
            child.AppendTo(this);
            var chain = Children.FirstOrDefault(c => c.Id.Equals(child.Id));
            if (chain != null) Children.Remove(chain);
            Children.Add(child);
        }

        public void Dispose()
        {
            foreach (var chain in Children) chain.Dispose();
            Children.Clear();

            if (_node != null) _node.Dispose();

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
