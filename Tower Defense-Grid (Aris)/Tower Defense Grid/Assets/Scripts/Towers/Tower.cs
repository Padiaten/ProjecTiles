using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {



    [SerializeField]
    private bool hits;

    [SerializeField]
    private bool AOEProj;

    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
    }

    [SerializeField]
    private float attackCooldown;

    [SerializeField]
    private float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
    }

    [SerializeField]
    private string effect;
    public string Effect
    {
        get { return effect; }
    }

    [SerializeField]
    private int effectValue;

	[SerializeField]
    private Projectile projectileObject;

    private SpriteRenderer sr;

    private MainEnemy enemy;
    public MainEnemy Enemy
    {
        get { return enemy; }
    }

    private Queue<MainEnemy> enemies = new Queue<MainEnemy>();

    private float attackTimer;
    private bool canAttack;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		UpdateRange();

        if(hits == true) Attack();

    }
      
	public void UpdateRange(){
		GetComponent<CircleCollider2D>().radius = Mathf.Max(transform.localScale.x,transform.localScale.y);
		//transform.s = new Vector3(GetComponent<CircleCollider2D>().radius,GetComponent<CircleCollider2D>().radius,transform.position.z);
	}

    private void Attack()
    {
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                canAttack = true;
                attackTimer = 0;
            }
        }

        if (enemy == null && enemies.Count > 0)
        {
            enemy = enemies.Dequeue();
        }

        if(enemy != null && enemy.isActiveAndEnabled && canAttack)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
		if(projectileObject == null){
			projectileObject = (Projectile)Resources.Load("Prefabs/Towers/Projectiles/Projectile", typeof(Projectile));
		}
        Projectile proj = Instantiate(projectileObject, this.transform.position, Quaternion.identity)as Projectile;
        proj.Initialize(this);

        canAttack = false;
    }

    public void Select()
    {
        sr.enabled = !sr.enabled;
    }


    public void DamageBuff(int value)
    {
        damage += value;
    }


    public void OnTriggerEnter2D(Collider2D o)
    {
        if (o.tag == "Enemy")
        {           
            if (hits == true)
            {
                enemies.Enqueue(o.GetComponent<MainEnemy>());
            }

            if (effect == "Slow")
            {
                o.GetComponent<MainEnemy>().EffectHit("Slow", effectValue);
            }
        }

        if (o.tag == "Tower")
        {
            if (effect == "DamageBuff")
            {
                o.GetComponentInChildren<Tower>().DamageBuff(effectValue);
            }
        }
    }


    public void OnTriggerExit2D(Collider2D o)
    {
        if(o.tag == "Enemy")
        {
            if (hits == true)
            {
                enemy = null;
            }

            if (effect == "Slow")
            {
                o.GetComponent<MainEnemy>().EffectHit("Restore Movement", effectValue);
            }
        }

        if (o.tag == "Tower")
        {
            if (effect == "DamageBuff")
            {
                o.GetComponentInChildren<Tower>().DamageBuff(effectValue);
            }
        }
    }

    
    

}
