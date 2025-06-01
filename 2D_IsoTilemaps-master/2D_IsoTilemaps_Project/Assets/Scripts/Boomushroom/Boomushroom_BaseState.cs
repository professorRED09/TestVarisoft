using UnityEngine;

public abstract class Boomushroom_BaseState 
{
    public abstract void EnterState(Boomushroom boomushroom);
    public abstract void UpdateState(Boomushroom boomushroom);
    public abstract void ExitState(Boomushroom boomushroom);
}
