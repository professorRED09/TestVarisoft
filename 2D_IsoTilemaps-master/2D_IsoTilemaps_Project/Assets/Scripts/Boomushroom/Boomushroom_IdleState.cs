using UnityEngine;

public class Boomushroom_IdleState : Boomushroom_BaseState
{
    public override void EnterState(Boomushroom boomushroom)
    {        
        boomushroom.animator.Play("Static");
    }

    public override void UpdateState(Boomushroom boomushroom)
    {
        //Debug.Log(boomushroom.distance + " LESS THAN " + boomushroom.chaseRange);
        //Debug.Log(boomushroom.distance <= boomushroom.chaseRange);
        if (boomushroom.distance <= boomushroom.chaseRange && boomushroom.player != null)
        {
            boomushroom.SwitchState(boomushroom.chaseState);
        }
    }

    public override void ExitState(Boomushroom boomushroom)
    {

    }
}
