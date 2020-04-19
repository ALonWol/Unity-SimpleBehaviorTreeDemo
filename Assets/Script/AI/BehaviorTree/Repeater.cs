namespace BehaviorTree {
    public class Repeater : Decorator, INode {
        private int times;

        private int count;

        public Repeater(int times = -1) {
            this.times = times;
            count = 0;
        }

        override public BehaviorTree.Status Excute() {
            while (count < times || times == -1) {
                var status = Node.Excute();

                switch (status) {
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        count = 0;
                        return Status.Failure;
                    case Status.Success:
                        count++;
                        break;
                    default:
                        break;
                }
            }

            return Status.Success;
        }
    }
}