using UnityEngine;

public class Actor : MonoBehaviour
{
    public string Name {get; protected set; }
    public int Level { get; protected set; }
    protected int XP;

    protected int MaxHP;
    public int HP { get; protected set; }
    protected bool _isDead = false;

    protected Collider _colider;
    protected Animator _animator;

     protected virtual void Start()
    {
        Level = 0;
        XP = 0;
        if(_colider == null) { _colider = GetComponent<Collider>(); }
        if (_animator == null) { _animator = GetComponent<Animator>(); }
    }

    public virtual void Attack(Vector3 enemyPos)
    {
        Debug.Log(Name + " is attacking");
    }

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP < 0)
        {
            HP = 0;
            Die();
            _isDead = true;
        }
    }

    public virtual void Die()
    {
        Destroy(this, 1f);
    }

    public virtual void Heal(int heal) 
    {
        HP += heal;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }
}
