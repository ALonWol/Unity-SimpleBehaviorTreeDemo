using UnityEngine;

public class RotateBehavior : BaseBehavior {
    override protected string onBehavior => "IsRotating";
    override protected string endBehavior => "EndRotate";
}
