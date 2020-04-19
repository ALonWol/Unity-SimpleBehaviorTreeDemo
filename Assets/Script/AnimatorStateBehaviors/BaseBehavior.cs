using UnityEngine;

public class BaseBehavior : StateMachineBehaviour {
    // 如果要灵活点，如果不止一个值，那就用Dictionary?
    virtual protected string onBehavior => "onBehavior";

    virtual protected string endBehavior => "endBehavior";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        animator.SetBool(onBehavior, true);
        animator.SetBool(endBehavior, false);
        Debug.Log("wtl------------------Enter onBehavior:" + onBehavior + " endBehavior:" + endBehavior);
    }

    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        
    // }

    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        Debug.Log("wtl------------------ Exit onBehavior:" + onBehavior + " endBehavior:" + endBehavior);
        animator.SetBool(onBehavior, false);
        animator.SetBool(endBehavior, true);
    }
}
