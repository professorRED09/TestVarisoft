using UnityEngine;

public class Fox_IdleState : Fox_BaseState
{
    public override void EnterState(Fox fox)
    {
        
    }

    public override void UpdateState(Fox fox)
    {
        fox.isoRenderer.SetDirection(fox.facingDir, fox.distance, fox.player);
        if (fox.distance <= fox.isoRenderer.chaseRange && fox.player != null)
        {
            fox.SwitchState(fox.chaseState);
        }
    }

    public override void ExitState(Fox fox)
    {

    }
}
