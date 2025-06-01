using UnityEngine;

public class Skeleton_IdleState : Skeleton_BaseState
{
    public override void EnterState(Skeleton skeleton)
    {
        skeleton.animator.Play("Static");
    }

    public override void UpdateState(Skeleton skeleton)
    {
        if(skeleton.distance <= skeleton.chaseRange && skeleton.player != null)
        {
            skeleton.SwitchState(skeleton.walkState);
        }
    }

    public override void ExitState(Skeleton skeleton)
    {
        
    }
}
