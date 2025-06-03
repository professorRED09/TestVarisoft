using UnityEngine;

public abstract class SSkeleton_BaseState 
{
    public abstract void EnterState(SSkeleton skeleton);
    public abstract void UpdateState(SSkeleton skeleton);
    public abstract void ExitState(SSkeleton skeleton);
}
