using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollerAttack : MonoBehaviour
{
    [SerializeField, Range(1,10)] private float _attackRange;

    private RaycastHit2D _hit;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        _hit = Physics2D.Raycast(transform.position, transform.forward * _attackRange);

        if(_hit.collider != null && _hit.rigidbody.gameObject.tag == TagsCheck.Player)
        {
            Debug.Log("Вижу игрока");
        }
    }

    
}
