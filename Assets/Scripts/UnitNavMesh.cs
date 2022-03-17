using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class UnitNavMesh
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _activeRadius;

    public void SetDestination(Vector3 point) => _navMeshAgent.SetDestination(point);

    public void Move(Vector3 position) => _navMeshAgent.Warp(position);

    public void ResetDestination() => _navMeshAgent.ResetPath();
    public bool IsStopped() => _navMeshAgent.remainingDistance <= _activeRadius;

    public void SetSpeed(float speed) => _navMeshAgent.speed = speed;

    public void SetAcceleration(bool active)
    {
        var value = active ? 500 : 0;
        _navMeshAgent.acceleration = value;
        _navMeshAgent.angularSpeed = value;
    }
}