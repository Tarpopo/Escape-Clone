using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PositionsTaker
{
    [SerializeField] private List<Transform> _positions;

    public Vector3 GetPosition() => _positions[Random.Range(0, _positions.Count)].position;
}