public class EnemyAttack : State<EnemyData>
{
    public EnemyAttack(EnemyData data, StateMachine<EnemyData> stateMachine) : base(data, stateMachine)
    {
    }

    public override void Enter()
    {
        Data.EmotionSprite.DoAnimation();
        Data.DamageableChecker.RotateToDamageable();
        Data.DamageableChecker.ApplyDamage();
        Data.LightChanger.ChangeColor(true);
        Data.AnimationComponent.PlayAnimation(UnitAnimations.FarAttack, true);
    }

    public override void PhysicsUpdate()
    {
        Data.EmotionSprite.RotateToCamera();
    }
}