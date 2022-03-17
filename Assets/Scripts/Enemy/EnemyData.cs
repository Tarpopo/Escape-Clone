using System;
using UnityEngine;

[Serializable]
public class EnemyData : BaseUnitData<UnitAnimations>
{
    public readonly Timer Timer = new Timer();
    public LightChanger LightChanger => _lightChanger;
    public EmotionSprite EmotionSprite => _emotionSprite;
    public float IdleTime => _idleTime;
    public float MoveTime => _moveTime;
    public PositionsTaker PositionsTaker => _positionsTaker;
    [SerializeField] private float _idleTime;
    [SerializeField] private float _moveTime;
    [SerializeField] private PositionsTaker _positionsTaker;
    [SerializeField] private LightChanger _lightChanger;
    [SerializeField] private EmotionSprite _emotionSprite;
}