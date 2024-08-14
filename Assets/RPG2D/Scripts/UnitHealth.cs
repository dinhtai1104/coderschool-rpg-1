using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private float maxHp;

    [SerializeField] private float currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            Debug.Log("Destroy: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}