using UnityEngine;

public class Skeleton_WalkState : Skeleton_BaseState
{
    public override void EnterState(Skeleton skeleton)
    {
        skeleton.animator.Play("Walk");
    }

    public override void UpdateState(Skeleton skeleton)
    {
        skeleton.ChasePlayer(); // chase player
        if (skeleton.distance > skeleton.chaseRange)
        {
            skeleton.SwitchState(skeleton.idleState);
        }
        else if (skeleton.distance <= skeleton.attackRange)
        {
            skeleton.SwitchState(skeleton.attackState);
        }
    }

    public override void ExitState(Skeleton skeleton)
    {
        
    }
}
