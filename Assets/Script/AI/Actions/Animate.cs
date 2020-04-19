using UnityEngine;
using BehaviorTree;

public class Animate : Node
{
    private Animator animator;

    private string name;

    private bool waitForEnd;

    private float length;

    public Animate(Animator animator, string name, bool waitForEnd = false) {
        this.animator = animator;
        this.name = name;
        this.waitForEnd = waitForEnd;
        length = 0;
    }

    override public Status Excute() {
        animator.Play(name);

        // Actually, animation will be played in next frame!
        // So we need to wait here
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(name)) {
            return Status.Running;
        }

        if (waitForEnd) {
            length += Time.deltaTime;
            if (length >= animator.GetCurrentAnimatorStateInfo(0).length) {
                length = 0;
                return Status.Success;
            } else {
                return Status.Running;
            }
        }

        length = 0;
        return Status.Success;
    }
}
