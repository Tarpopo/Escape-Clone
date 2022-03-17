using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> _onPlayerEnter;
    [SerializeField] private UnityEvent _onPlayerExit;

    public event UnityAction<GameObject> OnPlayerEnter
    {
        add => _onPlayerEnter.AddListener(value);
        remove => _onPlayerEnter.RemoveListener(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsType.Player.ToString()) == false) return;
        _onPlayerEnter?.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagsType.Player.ToString()) == false) return;
        _onPlayerExit?.Invoke();
    }
}