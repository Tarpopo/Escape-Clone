using System.Collections;
using UnityEngine;

[System.Serializable]
public class Rotator : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private Transform _propeller;
    [SerializeField] private bool _startOnEnable;
    [SerializeField] private Vector3 _rotation;

    public void SetRotateState(bool isActive)
    {
        if (isActive) StartCoroutine(Rotate());
        else StopAllCoroutines();
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            _propeller.Rotate(_rotation, _rotateSpeed);
            yield return Waiters.FixedUpdate;
        }
    }

    private void OnEnable() => SetRotateState(_startOnEnable);
    private void OnDisable() => StopAllCoroutines();
}