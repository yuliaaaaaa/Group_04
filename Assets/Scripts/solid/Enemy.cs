using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public int health = 50;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage" + damage);

        if(health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject, 1.5f);
    }
}
