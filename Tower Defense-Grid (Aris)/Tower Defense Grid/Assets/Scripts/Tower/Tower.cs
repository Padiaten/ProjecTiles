using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField]
    private float attackCooldown;

    [SerializeField]
    private float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
    }

    [SerializeField]
    private Projectile projectileObject;

    private SpriteRenderer sr;

    private Movement enemy;
    public Movement Enemy
    {
        get { return enemy; }
    }

    private Queue<Movement> enemies = new Queue<Movement>();
    private float attackTimer;
    private bool canAttack;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        projectileSpeed = 10;
    }
	
	// Update is called once per frame
	void Update () {

        Attack();

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
            Debug.Log("Bitch");
            enemy = enemies.Dequeue();
        }

        if(enemy != null && enemy.isActiveAndEnabled && canAttack)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        projectileObject = FindObjectOfType<Projectile>();
        Projectile proj = Instantiate(projectileObject, this.transform.position, Quaternion.identity)as Projectile;
        proj.Initialize(this);

        canAttack = false;
    }

    public void Select()
    {
        sr.enabled = !sr.enabled;
    }

    public void OnTriggerEnter2D(Collider2D o)
    {
        if(o.tag == "Enemy")
        {
            enemies.Enqueue(o.GetComponent<Movement>());
        }
    }

    public void OnTriggerExit2D(Collider2D o)
    {
        if(o.tag == "Enemy")
        {
            enemy = null;
        }
    }

    //GETTERS
    

}
