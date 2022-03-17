using System;
using UnityEngine;

[Serializable]
public abstract class BaseUnitData<T> where T : Enum
{
    public float MoveSpeed => _moveSpeed;
    public Health Health => health;
    public AnimationComponent<T> AnimationComponent => _animationComponent;
    public UnitNavMesh UnitNavMesh => _unitNavMesh;
    public DamageableChecker DamageableChecker => _damageableChecker;
    public Transform Transform => _transform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Health health;
    [SerializeField] private Transform _transform;
    [SerializeField] private AnimationComponent<T> _animationComponent;
    [SerializeField] private UnitNavMesh _unitNavMesh;
    [SerializeField] private DamageableChecker _damageableChecker;
}