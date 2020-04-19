using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class BTCharacter : BTAgent
{
    public Animator animator {get;set;}

    public List<GameObject> targets {get;set;}

    public GameObject currentTarget {get;set;}

    public SphereCollider senseCollider {get;set;}

    public TopText topText {get;set;}

    public Spawner spawner {get;set;}

    public float moveSpeed => 5.5f;

    public float rotateSpeed => 110;

    override protected void Setup() {
        animator = GetComponent<Animator>();
        targets = new List<GameObject>();
        senseCollider = GetComponent<SphereCollider>();
        topText = GetComponentInChildren<TopText>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

        /* Init BehaviorTree*/
        var priSel = new PrioritySelector();
        // Action:Idle
        var idleCond = new Condition();
        idleCond.condition = () => {
            topText.SetText("Action:Idle");
            return true;
        };
        priSel.AddChild(GetAnimationAction("Idle", false, new Idle(this), idleCond, 1));
        // Action:Rotate
        var rotateCond = new Condition();
        rotateCond.condition = CanRotate;
        priSel.AddChild(GetAnimationAction("Rotate", false, new Rotate(this),rotateCond, 3));
        // Action:Attack
        var attackCond = new Condition();
        attackCond.condition = CanAttack;
        priSel.AddChild(GetAnimationAction("Attack", true, new Attack(this), attackCond, 4));
        // Action:Move
        var moveCond = new Condition();
        moveCond.condition = CanMove;
        priSel.AddChild(GetAnimationAction("Move", false, new Move(this), moveCond, 2));
        // Action:FindTarget
        priSel.AddChild(new FindTarget(this, 5));

        brain = priSel;
    }

    public Node GetAnimationAction(string aniName, bool waiteForEnd, Node action, Condition condition, int priority) {
        var seq = new Sequence();
        seq.AddChild(condition);
        seq.AddChild(new Animate(animator, aniName, waiteForEnd));
        seq.AddChild(action);

        var dec = new Decorator(priority);
        dec.Node = seq;

        return dec;
    }

    float GetAngleToTarget() {
        var dir = (currentTarget.transform.position - transform.position).normalized;
        var angle = 90f - Mathf.Atan2(dir.z, dir.x) * 57.29578f/*PI / 180*/;
        angle = (angle + 360) % 360;
        return angle;
    }

    bool HasTarget() {
        return currentTarget != null && currentTarget.activeSelf;
    }

    bool CanAttack() {
        if (!HasTarget()) {
            return false;
        }

        var angleToTarget = GetAngleToTarget();
        if (Mathf.Abs(transform.rotation.eulerAngles.y - angleToTarget) > 1f) {
            return false;
        }

        if (Vector3.Distance(transform.position, currentTarget.transform.position) > 1.5) {
            return false;
        }

        topText.SetText("Action:Attack");
        return true;
    }

    bool CanRotate() {
        if (!HasTarget()) {
            return false;
        }

        var angleToTarget = GetAngleToTarget();
        if (Mathf.Abs(transform.rotation.eulerAngles.y - angleToTarget) <= 1f) {
            return false;
        }
        
        topText.SetText("Action:Rotate");
        return true;
    }

    bool CanMove() {
        bool result = HasTarget();
        if (result) {
            topText.SetText("Action:Move");
        }
        return result;
    }
}
