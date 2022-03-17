using UnityEngine;

public class EnemyIdle : State<EnemyData>
{
    public EnemyIdle(EnemyData data, StateMachine<EnemyData> stateMachine) : base(data, stateMachine)
    {
    }

    public override void Enter()
    {
        Data.AnimationComponent.PlayAnimation(UnitAnimations.Idle, true);
        Data.Timer.StartTimer(Random.Range(Data.IdleTime / 2, Data.IdleTime),
            () => Machine.ChangeState<EnemyMove>());
    }

    public override void PhysicsUpdate() => Data.Timer.UpdateTimer();
}