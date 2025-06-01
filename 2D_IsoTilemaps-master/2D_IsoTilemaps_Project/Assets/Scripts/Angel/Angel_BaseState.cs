using UnityEngine;

public abstract class Angel_BaseState 
{
    public abstract void EnterState(Angel angel);
    public abstract void UpdateState(Angel angel);
    public abstract void ExitState(Angel angel);
}
