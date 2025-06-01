using UnityEngine;

public class Angel_IdleState : Angel_BaseState
{
    public override void EnterState(Angel angel)
    {
        angel.animator.Play("Static");
    }

    public override void UpdateState(Angel angel)
    {
        if (angel.distance <= angel.attackRange && angel.player != null)
        {
            angel.SwitchState(angel.attackState);
        }
    }

    public override void ExitState(Angel angel)
    {

    }
}
