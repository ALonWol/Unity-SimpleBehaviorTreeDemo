namespace BehaviorTree {
    public class Selector : Composite, INode {
        override public Status Excute() {
            while (nodeIndex < Nodes.Count) {
                var status = Nodes[nodeIndex].Excute();

                switch (status) {
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        nodeIndex++;
                        break;
                    case Status.Success:
                        nodeIndex = 0;
                        return Status.Success;
                }
            }

            nodeIndex = 0;
            return Status.Failure;
        }
    }
}