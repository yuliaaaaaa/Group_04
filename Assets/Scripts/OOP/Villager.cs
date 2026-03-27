using UnityEngine;

public class Villager : Actor
{

    protected override void Start()
    {
        Name = "Villager";
        MaxHP = 30;
        base.Start();
    }
    public override void Attack(Vector3 enemyPos)
    {
        Debug.Log("I am villager, I can not attack");
    }
    private void OnTriggerEnter(Collider other)
    {
        Attack(other.transform.position);
    }
}
