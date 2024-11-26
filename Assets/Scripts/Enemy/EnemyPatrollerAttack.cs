using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(EnemyPatroller))]
public class EnemyPatrollerAttack : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float _attackRange;
    [SerializeField, Range(1, 2)] private float _speedMultiplier;


    private RaycastHit2D _hit;

    private MovementController _movementController;
    private EnemyPatroller _enemyPatroller;

    private const string PlayerLayer = nameof(PlayerLayer);
    private LayerMask _layerMask;

    private void Start()
    {
        _movementController = GetComponent<MovementController>();
        _enemyPatroller = GetComponent<EnemyPatroller>();

        _layerMask = LayerMask.GetMask(PlayerLayer);
    }

    private void FixedUpdate()
    {
        Vector2 faceDirection = _movementController.GetFaceDirection();

        _hit = Physics2D.Raycast(transform.position, transform.right * faceDirection, _attackRange, _layerMask);

        Debug.DrawRay(transform.position, transform.right * faceDirection * _attackRange, Color.red);

        if (_hit.collider != null)
        {
            _enemyPatroller.enabled = false;

            Vector3 pointOnEnemyLine = new Vector3(_hit.transform.position.x,
                                                transform.position.y,
                                                _hit.transform.position.z);

            Vector3 direction = (pointOnEnemyLine - transform.position).normalized;
            float horizontalMove = direction.x * _enemyPatroller.GetSpeed() * _speedMultiplier;

            _movementController.Move(horizontalMove * Time.fixedDeltaTime, false);
        }
        else
        {
            _enemyPatroller.enabled = true;
        }
    }
}
