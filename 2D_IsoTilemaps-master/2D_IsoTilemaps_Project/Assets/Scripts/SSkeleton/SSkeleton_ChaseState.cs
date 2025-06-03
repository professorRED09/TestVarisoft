using UnityEngine;

public class SSkeleton_ChaseState : SSkeleton_BaseState
{
    public override void EnterState(SSkeleton skeleton)
    {
        
    }

    public override void UpdateState(SSkeleton skeleton)
    {
        skeleton.isoRenderer.SetDirection(skeleton.facingDir, skeleton.distance, skeleton.player);
        skeleton.ChasePlayer(); // chase player
        if (skeleton.distance > skeleton.isoRenderer.chaseRange)
        {
            skeleton.SwitchState(skeleton.idleState);
        }
        else if (skeleton.distance <= skeleton.isoRenderer.attackRange)
        {
            skeleton.SwitchState(skeleton.attackState);
        }
    }

    public override void ExitState(SSkeleton skeleton)
    {
        
    }
}
