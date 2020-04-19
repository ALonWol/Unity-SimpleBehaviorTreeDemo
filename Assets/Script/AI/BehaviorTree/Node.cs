namespace BehaviorTree {
    public class Node : INode {
        public int priority {get; protected set;}

        public Node(int priority = 0) {
            this.priority = priority;
        }

        virtual public Status Excute() {
            return Status.Success;
        }
    }
}