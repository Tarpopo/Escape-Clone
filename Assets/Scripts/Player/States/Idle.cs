public class Idle : State<PlayerData>
{
    public Idle(PlayerData data, StateMachine<PlayerData> stateMachine) : base(data, stateMachine)
    {
    }

    public override void Enter() => Data.AnimationComponent.PlayAnimation(UnitAnimations.Idle, true);
}