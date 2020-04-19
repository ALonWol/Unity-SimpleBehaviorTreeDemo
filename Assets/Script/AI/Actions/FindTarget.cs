using UnityEngine;
using BehaviorTree;

public class FindTarget : Node
{
    private BTCharacter character;

    public FindTarget(BTCharacter character, int priority):base(priority) {
        this.character = character;
    }

    override public Status Excute() {
        if (character.targets.Count != 0) {
            return Status.Failure;
        }

        var hits = Physics.SphereCastAll(character.transform.position, character.senseCollider.radius, character.transform.forward, 100, 1 << LayerMask.NameToLayer("Target"));
        foreach (var hit in hits) {
            var go = hit.collider.gameObject;
            if (!character.targets.Contains(go)) {
                character.targets.Add(go);
            }
        }

        if (character.targets.Count == 0) {
            return Status.Failure;
        }
        
        return Status.Success;
    }
}
