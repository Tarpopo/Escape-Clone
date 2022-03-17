using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : Singleton<PlayerInput>
{
    [SerializeField] private float _activeRadius;
    [SerializeField] private UnityEvent _onMove;
    private Vector2 _startPosition;

    public event UnityAction OnMove
    {
        add => _onMove.AddListener(value);
        remove => _onMove.RemoveListener(value);
    }

    [SerializeField] private UnityEvent _onTouchDown;

    public event UnityAction OnTouchDown
    {
        add => _onTouchDown.AddListener(value);
        remove => _onTouchDown.RemoveListener(value);
    }

    [SerializeField] private UnityEvent _onTouchUp;

    public event UnityAction OnTouchUp
    {
        add => _onTouchUp.AddListener(value);
        remove => _onTouchUp.RemoveListener(value);
    }

    public bool ActiveRadius => Distance >= _activeRadius;
    //public bool IsMove => Input.GetMouseButton(0);


    public float Distance => Vector2.Distance(_startPosition, Input.mousePosition);
    public Vector3 MoveDirection => _startPosition - (Vector2) Input.mousePosition;

    public float Angle => AngleBetweenTwoPoints(_startPosition, Input.mousePosition);


    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) => Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
            _onTouchDown?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _onTouchUp?.Invoke();
        }
    }
}