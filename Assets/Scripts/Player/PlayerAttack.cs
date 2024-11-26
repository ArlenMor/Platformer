using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField, Range(1,2)] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeBtwAttack;
    [SerializeField] private Animator _animator;

    private static string IsAttack = nameof(IsAttack);
    private static string EnemyLayer = nameof(EnemyLayer);

    private LayerMask _enemysLayerMask;
    private float _timer;
    private WaitForSeconds _waitEndAnimation;

    private void Awake()
    {
        _waitEndAnimation = new WaitForSeconds(_timeBtwAttack);
        _enemysLayerMask = LayerMask.GetMask(EnemyLayer);
    }

    void Update()
    {
        Attack();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    private void Attack()
    {
        if(_timer <= 0)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(PlayAnimation());

                Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemysLayerMask);

                if(enemies.Length != 0)
                    foreach(Collider2D enemy in enemies)
                        Debug.Log($"Сущность {enemy.gameObject.name} получила {_damage} урона!");

                _timer = _timeBtwAttack;
            }
        }else
        {
            _timer -= Time.deltaTime;
        }
    }

    private IEnumerator PlayAnimation()
    {
        _animator.SetBool(IsAttack, true);
        yield return _waitEndAnimation;
        _animator.SetBool(IsAttack, false);
    }
}
