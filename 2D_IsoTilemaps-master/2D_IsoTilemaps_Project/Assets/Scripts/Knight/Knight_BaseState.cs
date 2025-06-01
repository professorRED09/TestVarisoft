using UnityEngine;

public abstract class Knight_BaseState 
{
    public abstract void EnterState(Knight knight);
    public abstract void UpdateState(Knight knight);
    public abstract void ExitState(Knight knight);
}
