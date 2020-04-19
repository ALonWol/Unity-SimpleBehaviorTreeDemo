namespace BehaviorTree {
    public class Sequence : Composite, INode {
        override public Status Excute() {

            while (nodeIndex < Nodes.Count) {
                var status = Nodes[nodeIndex].Excute();

                switch (status) {
                    case Status.Running:
                        return Status.Running;
                    case Status.Success:
                        nodeIndex++;
                        break;
                    case Status.Failure:
                        return Status.Failure;
                }
            }

            nodeIndex = 0;
            return Status.Success;
        }
    }
}
