using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    public int damage = 10;

    public void AttackWeapon(IDamagable target)
    {
        target.TakeDamage(damage);
        Debug.Log("Gun shoot");
    }
}
