using UnityEngine;

public class Fox_ChaseState : Fox_BaseState
{
    public override void EnterState(Fox fox)
    {        
        
    }

    public override void UpdateState(Fox fox)
    {
        fox.isoRenderer.SetAnimationRun(fox.facingDir);
        fox.ChasePlayer();
        if (fox.distance <= fox.isoRenderer.readyRange && fox.player != null)
        {
            fox.Bomb();
        }else if (fox.player == null)
        {
            fox.SwitchState(fox.idleState);
        }
    }

    public override void ExitState(Fox fox)
    {

    }
}
