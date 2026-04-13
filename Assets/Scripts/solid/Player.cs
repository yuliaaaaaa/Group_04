using UnityEngine;

public class Player : MonoBehaviour
{
    private IWeapon currentWeapon;

    public void SetWeapon(IWeapon weapon)
    {
        currentWeapon = weapon;
    }

    public void Attack(IDamagable target)
    {
        if(currentWeapon == null)
        {
            Debug.Log("No weapon");
            return;
        }

        currentWeapon.AttackWeapon(target);
    }
}
