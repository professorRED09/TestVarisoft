using UnityEngine;

public class SSkeleton_IdleState : SSkeleton_BaseState
{
    public override void EnterState(SSkeleton skeleton)
    {
       
    }

    public override void UpdateState(SSkeleton skeleton)
    {
        skeleton.isoRenderer.SetDirection(skeleton.facingDir, skeleton.distance, skeleton.player);
        if (skeleton.distance <= skeleton.isoRenderer.chaseRange && skeleton.player != null)
        {
            skeleton.SwitchState(skeleton.chaseState);
        }
    }

    public override void ExitState(SSkeleton skeleton)
    {
        
    }
}
