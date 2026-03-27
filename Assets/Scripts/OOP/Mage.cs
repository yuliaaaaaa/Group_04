using UnityEngine;

public class Mage : Actor
{
    [SerializeField] GameObject AttackParticles;
    [SerializeField] GameObject DieParticles;

    private bool isAttacking = false;
    Rigidbody rbPar;
    Vector3 enemyTransform;
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

        GameObject attackParticles = Instantiate(AttackParticles, transform.position, Quaternion.identity);
        rbPar = attackParticles.GetComponent<Rigidbody>();
        isAttacking = true;

    }

    private void Update()
    {
        if (isAttacking) 
        {
            rbPar.linearVelocity = new Vector3(enemyTransform.x * Time.deltaTime, enemyTransform.y * Time.deltaTime, enemyTransform.z * Time.deltaTime);
        }
        if( rbPar!=null && enemyTransform !=null && rbPar.transform.position == enemyTransform)
        {
            isAttacking = false;
            Destroy(rbPar.gameObject);
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
