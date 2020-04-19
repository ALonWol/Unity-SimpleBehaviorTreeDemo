using UnityEngine;
using BehaviorTree;

public class Rotate : Node
{
    private BTCharacter character;

    public Rotate(BTCharacter character) {
        this.character = character;
    }

    override public BehaviorTree.Status Excute() {
        var dir = (character.currentTarget.transform.position - character.transform.position).normalized;
        var rotateAngle = 90f - Mathf.Atan2(dir.z, dir.x) * 57.29578f/*PI / 180*/;
        rotateAngle = (rotateAngle + 360) % 360;

        if (Mathf.Abs(character.transform.rotation.eulerAngles.y - rotateAngle) > 1f) {
            float angle = Mathf.MoveTowardsAngle(character.transform.rotation.eulerAngles.y, rotateAngle, character.rotateSpeed * Time.deltaTime);
            character.transform.rotation = Quaternion.Euler(0, angle, 0);

            return Status.Running;
        }

        return Status.Success;
    }
}
