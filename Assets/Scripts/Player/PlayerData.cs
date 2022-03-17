using System;
using UnityEngine;

[Serializable]
public class PlayerData : BaseUnitData<UnitAnimations>
{
    [SerializeField] private float _angleOffset;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Weapon _weapon;
    public float AttackDelay => _attackDelay;
    public float AngleOffset => _angleOffset;
    public Weapon Weapon => _weapon;
    public readonly Timer Timer = new Timer();
}