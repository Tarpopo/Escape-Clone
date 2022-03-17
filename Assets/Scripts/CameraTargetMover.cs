using System;
using UnityEngine;

public class CameraTargetMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    private Vector3 _direction;

    private void Start() => _direction = (transform.position - _target.position);

    private void FixedUpdate()
    {
        if (_target == null) return;
        var position = _target.position + _direction;
        transform.position = Vector3.Lerp(transform.position, position, _speed);
    }
}
