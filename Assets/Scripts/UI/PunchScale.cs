using DG.Tweening;
using UnityEngine;

public class PunchScale : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _scale;

    public void DoAnimation() => _transform.DOPunchScale(_scale, _duration);
}