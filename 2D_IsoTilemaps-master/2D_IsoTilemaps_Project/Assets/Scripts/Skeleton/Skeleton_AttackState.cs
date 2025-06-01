using UnityEngine;

public class Skeleton_AttackState : Skeleton_BaseState
{
    public override void EnterState(Skeleton skeleton)
    {
        skeleton.animator.Play("Attack");
    }

    public override void UpdateState(Skeleton skeleton)
    {
        // attack player
        if (skeleton.distance > skeleton.attackRange)
        {
            skeleton.SwitchState(skeleton.walkState);
        }
        
    }

    public override void ExitState(Skeleton skeleton)
    {
        
    }
}
