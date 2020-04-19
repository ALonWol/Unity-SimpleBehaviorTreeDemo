using UnityEngine;
using BehaviorTree;

public class Wait : Node
{
    private float seconds;

    private float time;

    public Wait(float seconds) {
        this.seconds = seconds;
    }

    override public BehaviorTree.Status Excute() {
        time += Time.deltaTime;
        while (time < seconds) {
            return Status.Running;
        }

        time = 0;
        return Status.Success;
    }
}
