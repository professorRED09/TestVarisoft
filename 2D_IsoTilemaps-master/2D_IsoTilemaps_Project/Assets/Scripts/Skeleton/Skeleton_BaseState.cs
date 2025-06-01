using UnityEngine;

public abstract class Skeleton_BaseState 
{
    public abstract void EnterState(Skeleton skeleton);
    public abstract void UpdateState(Skeleton skeleton);
    public abstract void ExitState(Skeleton skeleton);
}
