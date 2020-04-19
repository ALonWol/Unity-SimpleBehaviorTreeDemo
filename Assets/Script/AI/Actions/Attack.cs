using UnityEngine;
using BehaviorTree;

public class Attack : Node
{
    private BTCharacter character;

    public Attack(BTCharacter character) {
        this.character = character;
    }

    override public Status Excute() {
        character.spawner.KillGrunt(character.currentTarget);
        character.currentTarget = null;
        return Status.Success;
    }
}
