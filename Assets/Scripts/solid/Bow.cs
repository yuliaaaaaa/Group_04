using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    public int damage = 5;

    public void AttackWeapon(IDamagable target)
    {
        target.TakeDamage(damage);
        Debug.Log("Bow shoot");
    }
}
