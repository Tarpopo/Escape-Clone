using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class EmotionSprite : MonoBehaviour
{
    [SerializeField] private GameObject _sprite;
    [SerializeField] private int _visibleTime;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _scale;
    private Transform _camera;

    public void DoAnimation()
    {
        _sprite.SetActive(true);
        _sprite.transform.DOPunchScale(_scale, _duration);
    }

    public void RotateToCamera() => _sprite.transform.LookAt(_camera);
    
    private void Start()
    {
        _sprite.SetActive(false);
        _camera = Camera.main.transform;
    }
}