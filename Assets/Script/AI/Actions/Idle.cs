using UnityEngine;
using BehaviorTree;

public class Idle : Node
{
    private BTCharacter character;

    public Idle(BTCharacter character) {
        this.character = character;
    }

    override public Status Excute() {
        character.animator.Play("Idle");

        if ((character.currentTarget == null || !character.currentTarget.activeSelf) && character.targets.Count > 0) {
            character.currentTarget = character.targets[0];
            character.targets.Remove(character.currentTarget);
        }

        return Status.Success;
    }
}
