using UnityEngine;

public class Knight_WalkState : Knight_BaseState
{
    public override void EnterState(Knight knight)
    {
        
    }

    public override void UpdateState(Knight knight)
    {
        knight.isoRenderer.SetDirection(knight.facingDir, knight.distance, knight.player);
        knight.ChasePlayer(); // chase player
        if (knight.distance > knight.isoRenderer.chaseRange)
        {
            knight.SwitchState(knight.idleState);
        }
        else if (knight.distance <= knight.isoRenderer.attackRange)
        {
            knight.SwitchState(knight.attackState);
        }
    }

    public override void ExitState(Knight knight)
    {
        
    }
}
