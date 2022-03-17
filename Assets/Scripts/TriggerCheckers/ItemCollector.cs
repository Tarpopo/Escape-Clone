using Interfaces;
using UnityEngine;

public class ItemCollector : MonoBehaviour, IItemCollector
{
    [SerializeField] private TagsType _tagsType;
    [SerializeField] private Weapon _weapon;
    public void OnItemCollected(WeaponItem weapon) => _weapon.ActivateWeapon();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IItem>(out var item) == false || other.CompareTag(_tagsType.ToString()) == false) return;
        item.Collect(this);
    }
}