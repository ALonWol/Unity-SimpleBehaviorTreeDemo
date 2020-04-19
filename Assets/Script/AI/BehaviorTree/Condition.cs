using System;

namespace BehaviorTree {
    public class Condition : Node, INode {
        public Func<bool> condition {get; set;}

        override public Status Excute() {
            if (condition()) {
                return Status.Success;
            }

            return Status.Failure;
        }
    }
}
