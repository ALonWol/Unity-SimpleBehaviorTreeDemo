using System.Collections.Generic;

namespace BehaviorTree {
    public abstract class Composite : Node, INode
    {
        private List<Node> nodes;
        public List<Node> Nodes {
            get {
                if (nodes == null) {
                    nodes = new List<Node>();
                }
                return nodes;
            }
        }

        protected int nodeIndex = 0;

        public Composite() {
        }

        virtual public void AddChild(Node child) {
            Nodes.Add(child);
        }
    }
}