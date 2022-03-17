using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public Vector3 Position => transform.position;

    public event UnityAction OnTakeDamage
    {
        add => _onTakeDamage.AddListener(value);
        remove => _onTakeDamage.RemoveListener(value);
    }

    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onTakeDamage;
    private int _currentHealth;
    private bool _dead => _currentHealth <= 0;
    private void ResetHealth() => _currentHealth = _health;
    private void OnEnable() => ResetHealth();

    public void TakeDamage(int damage = 1)
    {
        if (_dead) return;
        _currentHealth -= damage;
        _onTakeDamage?.Invoke();
    }
}