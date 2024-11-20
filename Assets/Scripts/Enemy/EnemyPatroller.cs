using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private Transform _patrolWaypointsHolder;
    [SerializeField] private float _speed;

    private MovementController _controller;
    private Transform[] _patrolWaypoints;
    private Vector3 _direction = Vector3.zero;

    private float _offset = 0.1f;
    private float _horizontalMove;
    private int _currentWaypoint = 0;
    private bool _hasDirection = false;

    private void Awake()
    {
        _controller = GetComponent<MovementController>();

        _patrolWaypoints = new Transform[_patrolWaypointsHolder.childCount];

        for (int i = 0; i < _patrolWaypoints.Length; i++)
            _patrolWaypoints[i] = _patrolWaypointsHolder.GetChild(i);

        GetDirectionToNextPoint();
    }

    private void Update()
    {
        _horizontalMove = _direction.x * _speed;

        if (Vector2.Distance(transform.position, _patrolWaypoints[_currentWaypoint].position) <= _offset)
        {
            _currentWaypoint = ++_currentWaypoint % _patrolWaypoints.Length;
            _hasDirection = false;
        }

        if (_hasDirection == false)
            GetDirectionToNextPoint();
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.deltaTime, false);
    }

    public void CollisionWithPlayer()
    {
        //some logic
    }

    private void GetDirectionToNextPoint()
    {
        if (_patrolWaypoints.Length == 0)
            return;

        Vector3 pointOnEnemyLine = new Vector3(_patrolWaypoints[_currentWaypoint].position.x,
                                                transform.position.y,
                                                _patrolWaypoints[_currentWaypoint].position.z);

        _direction = (pointOnEnemyLine - transform.position).normalized;
        _hasDirection = true;
    }

    
}