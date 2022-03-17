using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerTriggerChecker))]
public class Portal : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPortalEnd;
    [SerializeField] private Transform _endPoin;
    [SerializeField] private GameObject _potalParticles;
    [SerializeField] private ParticleSystem _portalEnd;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private int _vibrato;
    private PlayerTriggerChecker _playerTriggerChecker;

    private void Start()
    {
        _playerTriggerChecker = GetComponent<PlayerTriggerChecker>();
        _playerTriggerChecker.OnPlayerEnter += TeleportObject;
    }

    private void TeleportObject(GameObject player)
    {
        _potalParticles.transform.DOPunchScale(_scale, _duration, _vibrato).onComplete = () =>
        {
            _potalParticles.SetActive(false);
            _portalEnd.Play();
            player.SetActive(false);
            player.transform.position = _endPoin.position;
            _onPortalEnd?.Invoke();
        };
    }
}