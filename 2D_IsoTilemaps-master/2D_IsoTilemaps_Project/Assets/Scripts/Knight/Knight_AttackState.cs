using UnityEngine;

public class Knight_AttackState : Knight_BaseState
{
    public override void EnterState(Knight knight)
    {
        
    }

    public override void UpdateState(Knight knight)
    {
        if (knight.distance > knight.isoRenderer.attackRange && knight.player != null)
        {
            knight.SwitchState(knight.walkState);
        }
    }

    public override void ExitState(Knight knight)
    {
        
    }
}
