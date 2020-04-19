using UnityEngine;

public class AttackBehavior : BaseBehavior {
    override protected string onBehavior => "IsAttacking";
    override protected string endBehavior => "EndAttack";
}
