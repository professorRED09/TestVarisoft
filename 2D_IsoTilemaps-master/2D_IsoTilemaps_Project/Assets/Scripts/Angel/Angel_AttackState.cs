using UnityEngine;

public class Angel_AttackState : Angel_BaseState
{
    public override void EnterState(Angel angel)
    {
        angel.animator.Play("Attack");
    }

    public override void UpdateState(Angel angel)
    {
        if (angel.distance > angel.attackRange)
        {
            angel.SwitchState(angel.idleState);
        }
    }

    public override void ExitState(Angel angel)
    {
        
    }
}
