using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private CharacterAnimation characterAnimation;

    [SerializeField] private int normalDamage;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform normalAttackPos;
    [SerializeField] private float normalAttackRange;

    public void Attack()
    {
        characterAnimation.SetTrigger("attack");
    }

    public void AttackEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(normalAttackPos.position, normalAttackRange, enemyLayer);
        
        foreach (var collider in colliders)
        {
            Debug.Log("Attack to: " + collider.name);
            UnitHealth healthEnemy = collider.GetComponent<UnitHealth>();
            healthEnemy.TakeDamage(normalDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(normalAttackPos.position, normalAttackRange);
    }
}