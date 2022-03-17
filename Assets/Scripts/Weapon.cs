using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool CanDamage => _weaponPrefab.activeSelf;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _weaponPrefab;

    public void Attack(IDamageable damageable) => damageable.TakeDamage(_damage);

    public void ActivateWeapon() => _weaponPrefab.SetActive(true);

    private void Start()
    {
        if (_weaponPrefab == null) return;
        _weaponPrefab.SetActive(false);
    }
}