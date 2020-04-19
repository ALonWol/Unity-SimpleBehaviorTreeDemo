using System;

namespace BehaviorTree {
    public class Decorator : Node
    {
        public INode Node {get; set;}

        public Decorator(int priority = 0) : base(priority) {}
    
        override public Status Excute() {
            if (Node == null) {
                throw new Exception("Node is null!");
            }

            return Node.Excute();
        }
    }
}