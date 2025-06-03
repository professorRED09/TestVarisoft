using UnityEngine;

public abstract class Fox_BaseState 
{
    public abstract void EnterState(Fox fox);
    public abstract void UpdateState(Fox fox);
    public abstract void ExitState(Fox fox);
}
