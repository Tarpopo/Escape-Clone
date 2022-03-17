public class Death : State<PlayerData>
{
    public Death(PlayerData data, StateMachine<PlayerData> stateMachine) : base(data, stateMachine)
    {
    }

    public override void Enter() => Data.AnimationComponent.PlayAnimation(UnitAnimations.Death, true);

    public override bool IsStatePlay() => true;
}