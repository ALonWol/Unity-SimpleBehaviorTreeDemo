namespace BehaviorTree {
    public class PrioritySelector : Selector, INode
    {
        override public void AddChild(Node child) {
            base.AddChild(child);
            // Greater priority in first!
            Nodes.Sort((a, b) => {
                int result = a.priority - b.priority;
                if (result == 0) {
                    return 0;
                } else if (result > 0) {
                    return -1;
                } else {
                    return 1;
                }
            });
        }
    }
}