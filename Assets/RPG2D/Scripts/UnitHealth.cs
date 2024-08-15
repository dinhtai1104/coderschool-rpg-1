using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    private Actor actor;
    private float maxHp;
    [SerializeField] private float currentHp;

    public void Init(Actor actor)
    {
        this.actor = actor;
    }

    public void SetMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        bool isDead = false;
        if (currentHp < 0)
        {
            isDead = true;
        }

        actor.UpdateHealthbar(currentHp / maxHp, isDead);
    }
}