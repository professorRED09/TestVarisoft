using UnityEngine;

public class Boomushroom_ChaseState : Boomushroom_BaseState
{
    public override void EnterState(Boomushroom boomushroom)
    {        
        Debug.Log("BoomRUN");
        boomushroom.animator.Play("Run");
    }

    public override void UpdateState(Boomushroom boomushroom)
    {        
        boomushroom.ChasePlayer();
        if (boomushroom.distance <= boomushroom.readyRange && boomushroom.player != null)
        {
            boomushroom.Bomb();
        }else if (boomushroom.player == null)
        {
            boomushroom.SwitchState(boomushroom.idleState);
        }
    }

    public override void ExitState(Boomushroom boomushroom)
    {

    }
}
