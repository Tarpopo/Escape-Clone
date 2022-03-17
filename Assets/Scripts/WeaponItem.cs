using Interfaces;
using UnityEngine;

public class WeaponItem : MonoBehaviour, IItem
{
    public void Collect(IItemCollector itemCollector)
    {
        itemCollector.OnItemCollected(this);
        gameObject.SetActive(false);
    }
}