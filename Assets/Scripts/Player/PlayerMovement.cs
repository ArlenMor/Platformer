using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    [SerializeField, Range(100, 500)] private float _speed = 300f;

    private PlayerController _controller;

    private float horizontalMove = 0f;
    private bool jump = false;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw(Horizontal) * _speed;

        if(Input.GetButtonDown(Jump))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        _controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
