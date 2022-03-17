
public class EnemyMove : State<EnemyData>
{
    public EnemyMove(EnemyData data, StateMachine<EnemyData> stateMachine) : base(data, stateMachine)
    {
    }

    public override void Enter()
    {
        Data.UnitNavMesh.SetDestination(Data.PositionsTaker.GetPosition());
        Data.AnimationComponent.PlayAnimation(UnitAnimations.Run, true);
    }

    public override void Exit()
    {
        Data.UnitNavMesh.ResetDestination();
    }

    public override void LogicUpdate()
    {
        if (Data.UnitNavMesh.IsStopped() == false) return;
        Machine.ChangeState<EnemyIdle>();
    }
}