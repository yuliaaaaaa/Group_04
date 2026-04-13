using UnityEngine;

public class Mage : Actor
{
    [SerializeField] GameObject AttackParticles;
    [SerializeField] GameObject DieParticles;

    [SerializeField] float speed = 1.2f;

    private bool isAttacking = false;
    Vector3 enemyTransform;

    GameObject attackParticles;
    protected override void Start()
    {
        Name = "Mage";
        MaxHP = 85;
        base.Start();
    }

    public override void Attack(Vector3 enemyPos)
    {
        base.Attack(enemyPos);
        enemyTransform = enemyPos;

        attackParticles = Instantiate(AttackParticles, transform.position, Quaternion.identity);
        isAttacking = true;

    }

    private void Update()
    {
        if (isAttacking) 
        {
            AttackParticles.transform.position = Vector3.MoveTowards(attackParticles.transform.position, enemyTransform, speed * Time.deltaTime);
        }
        if(isAttacking && Vector3.Distance(attackParticles.transform.position , enemyTransform) < 0.2)
        {
            isAttacking = false;
            Destroy(attackParticles);
        }

    }
    public override void Die()
    {
        GameObject dieParticles = Instantiate(DieParticles, transform.position, Quaternion.identity);
        
        Destroy(dieParticles, 2f);

        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        Destroy(gameObject, 2.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack(other.transform.position);
        }
    }
}
