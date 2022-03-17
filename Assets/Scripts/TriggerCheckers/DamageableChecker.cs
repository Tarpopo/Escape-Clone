using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DamageableChecker : MonoBehaviour
{
    public bool CanAttack => _damageable != null;
    [SerializeField] private int _damage;
    [SerializeField] private UnityEvent _onGetDamageable;
    [SerializeField] private TagsType _tagsType;
    [SerializeField] private Transform _rotateable;
    private IDamageable _damageable;

    public event UnityAction OnGetDamageable
    {
        add => _onGetDamageable.AddListener(value);
        remove => _onGetDamageable.RemoveListener(value);
    }

    public void ApplyDamage()
    {
        if (CanAttack == false) return;
        _damageable.TakeDamage(_damage);
        _damageable = null;
    }

    public void RotateToDamageable() => _rotateable.DOLookAt(_damageable.Position, 0.5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _damageable) == false || other.CompareTag(_tagsType.ToString()) == false) return;
        _onGetDamageable?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out _damageable) == false || other.CompareTag(_tagsType.ToString()) == false) return;
        _damageable = null;
    }
}