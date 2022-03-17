using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class LightChanger
{
    [SerializeField] private Light _light;
    [SerializeField] private float _duration;
    [SerializeField] private float _startRange;
    [SerializeField] private float _endRange;

    public void ChangeColor(bool activeLight)
    {
        _light.DOColor(activeLight ? Color.red : Color.white, _duration);
        _light.range = activeLight ? _endRange : _startRange;
    }
}