namespace BehaviorTree {
    public enum Status {
        Failure,
        Success,
        Running
    }
    public interface INode
    {
        Status Excute();
    }
}
