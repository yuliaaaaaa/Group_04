using UnityEngine;  

public class GameCont : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Gun gun;
    public Bow bow;

    void Start()
    {
        player.SetWeapon(gun);

        player.Attack(enemy);

        player.SetWeapon(bow);
        player.Attack(enemy);

    }
}
