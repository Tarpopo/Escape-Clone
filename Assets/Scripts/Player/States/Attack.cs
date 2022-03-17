using UnityEngine;

public class Attack : State<PlayerData>
{
    public Attack(PlayerData data, StateMachine<PlayerData> stateMachine) : base(data, stateMachine)
    {
    }

    public override void Enter()
    {
        Data.Timer.StartTimer(Data.AttackDelay, () =>
        {
            Data.DamageableChecker.ApplyDamage();
            Machine.ChangeState<Idle>();
        });
        Data.AnimationComponent.PlayAnimation(UnitAnimations.MeleeAttack, true);
    }

    public override void PhysicsUpdate() => Data.Timer.UpdateTimer();
}