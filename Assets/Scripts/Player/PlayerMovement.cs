using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    [SerializeField, Range(100, 500)] private float _speed = 300f;

    private MovementController _controller;
    private Animator _animator;

    private float horizontalMove = 0f;
    private bool jump = false;

    private void Awake()
    {
        _controller = GetComponent<MovementController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw(Horizontal) * _speed;

        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

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
