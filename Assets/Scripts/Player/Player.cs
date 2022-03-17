using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnable;
    [SerializeField] private PlayerData _playerData;
    private readonly StateMachine<PlayerData> _stateMachine = new StateMachine<PlayerData>();

    private void OnEnable() => _onEnable?.Invoke();

    private void Start()
    {
        _stateMachine.AddState(new Idle(_playerData, _stateMachine));
        _stateMachine.AddState(new Move(_playerData, _stateMachine));
        _stateMachine.AddState(new Death(_playerData, _stateMachine));
        _stateMachine.AddState(new Attack(_playerData, _stateMachine));
        _stateMachine.Initialize<Idle>();
        _playerData.Health.OnTakeDamage += () => _stateMachine.ChangeState<Death>();
        PlayerInput.Instance.OnTouchDown += () => _stateMachine.ChangeState<Move>();
        PlayerInput.Instance.OnTouchUp += () =>
        {
            if (_playerData.DamageableChecker.CanAttack && _playerData.Weapon.CanDamage)
                _stateMachine.ChangeState<Attack>();
            else _stateMachine.ChangeState<Idle>();
        };
    }

    private void Update() => _stateMachine.CurrentState.LogicUpdate();

    private void FixedUpdate() => _stateMachine.CurrentState.PhysicsUpdate();
}