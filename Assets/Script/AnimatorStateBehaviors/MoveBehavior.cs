using UnityEngine;

public class MoveBehavior : BaseBehavior {
    override protected string onBehavior => "IsMoving";
    override protected string endBehavior => "EndMove";
}
