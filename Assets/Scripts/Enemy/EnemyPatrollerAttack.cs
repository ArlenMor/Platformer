using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyPatrollerAttack : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float _attackRange;

    private RaycastHit2D _hit;
    private MovementController _movementController;

    private void Start()
    {
        _movementController = GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        LayerMask playerLayerMask = LayerMask.GetMask("Player");
        Vector2 faceDirection = _movementController.GetFaceDirection();

        _hit = Physics2D.Raycast(transform.position, transform.right * faceDirection, _attackRange, playerLayerMask);

        Debug.DrawRay(transform.position, transform.right * faceDirection * _attackRange, Color.red);

        if (_hit.collider != null)
        {
            Debug.Log("Вижу игрока");
        }
    }
}
