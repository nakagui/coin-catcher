using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocityX = _movement.x * _speed;
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>().normalized;
    }
}
