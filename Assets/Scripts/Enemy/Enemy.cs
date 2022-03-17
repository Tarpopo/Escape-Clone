using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private float _disableTime;
    private readonly StateMachine<EnemyData> _stateMachine = new StateMachine<EnemyData>();

    private void Start()
    {
        _stateMachine.AddState(new EnemyIdle(_enemyData, _stateMachine));
        _stateMachine.AddState(new EnemyMove(_enemyData, _stateMachine));
        _stateMachine.AddState(new EnemyAttack(_enemyData, _stateMachine));
        _stateMachine.AddState(new EnemyDeath(_enemyData, _stateMachine));
        _enemyData.DamageableChecker.OnGetDamageable += () => _stateMachine.ChangeState<EnemyAttack>();
        _enemyData.Health.OnTakeDamage += () =>
        {
            _stateMachine.ChangeState<EnemyDeath>();
            Invoke(nameof(Disable), _disableTime);
        };
        _stateMachine.Initialize<EnemyIdle>();
    }

    private void Update() => _stateMachine.CurrentState.LogicUpdate();

    private void FixedUpdate() => _stateMachine.CurrentState.PhysicsUpdate();

    private void Disable()
    {
        _deathParticles.transform.SetParent(null);
        _deathParticles.Play();
        gameObject.SetActive(false);
    }
}