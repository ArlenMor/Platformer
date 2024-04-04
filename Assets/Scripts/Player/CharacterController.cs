using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action OnGrounding;

    private const float GroundedRadius = .2f;

    [SerializeField] private float _jumpForce = 400f;
    [SerializeField, Range(0, .3f)] private float _movementSmoothing = .05f;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigitbody2D;

    private bool _grounded;
    private bool _facingLeft = true;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = _grounded;
        _grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius);

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _grounded = true;

                if(wasGrounded == false)
                    OnGrounding?.Invoke();
            }
        }
    }

    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move, _rigitbody2D.velocity.y);
        _rigitbody2D.velocity = Vector3.SmoothDamp(_rigitbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

        if (move > 0 && _facingLeft == true)
            Flip();
        else if (move < 0 && _facingLeft == false)
            Flip();

        if(_grounded && jump)
        {
            _grounded = false;
            _rigitbody2D.AddForce(new Vector2(0, _jumpForce));
        }
    }

    private void Flip()
    {
        _facingLeft = !_facingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
