using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CubeSideChanger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onChangeEnd;
    [SerializeField] private List<CubeSide> _cubeSides;
    [SerializeField] private float _duration;

    public void ChangeSide()
    {
        _cubeSides[0].SetActiveObjects(false);
        _cubeSides.RemoveAt(0);
        transform.DORotate(_cubeSides[0].Rotation, _duration).onComplete = () =>
        {
            _cubeSides[0].SetActiveObjects(true);
            _onChangeEnd?.Invoke();
        };
    }
}

[Serializable]
public class CubeSide
{
    public Vector3 Rotation;
    [SerializeField] private List<GameObject> _gameObjects;

    public void SetActiveObjects(bool active)
    {
        foreach (var gameObject in _gameObjects) gameObject.SetActive(active);
    }
}