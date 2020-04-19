using UnityEngine;
using BehaviorTree;

public class Move : Node
{
    private BTCharacter character;

    public Move(BTCharacter character) {
        this.character = character;
    }

    override public BehaviorTree.Status Excute() {

        if (Vector3.Distance(character.transform.position, character.currentTarget.transform.position) > 1.5) {
            var moveDirection = (character.currentTarget.transform.position - character.transform.position).normalized;
            character.transform.position += moveDirection * character.moveSpeed * Time.deltaTime;

            return Status.Running;
        }

        return Status.Success;
    }
}
