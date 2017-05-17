using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private bool roundhouseF = false;

    private Vector3 direction;

    private MainEnemy enemy;
    private Tower sourceTower;

    private BoxCollider2D bCol;
    private CircleCollider2D cCol;

    private List<MainEnemy> damagedEnemies;

    // Use this for initialization
    void Start() {
        bCol = GetComponent<BoxCollider2D>();
        cCol = GetComponent<CircleCollider2D>();

        if(sourceTower != null)
             roundhouseF = sourceTower.MultipleRoundhouseHit;
    }

    // Update is called once per frame
    void Update() {
        if (roundhouseF) Move();
        else MovetoEnemy();
    }

    public void Initialize(Tower sourceTower, Vector2 dir)
    {
        this.sourceTower = sourceTower;
        enemy = sourceTower.Enemy;
        direction = dir;
    }

    void MovetoEnemy()
    {
        if (enemy != null && enemy.isActiveAndEnabled)
        {

            Vector3 diff = enemy.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position,
                                                     Time.deltaTime * sourceTower.ProjectileSpeed);
        }
        else if (enemy == null)
        {
            Destroy(this.gameObject);
        }
    }


    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * sourceTower.ProjectileSpeed);
    }


    public void OnTriggerEnter2D(Collider2D o)
    {
        if (sourceTower.MultipleRoundhouseHit)
        {
            if(o.tag == "Enemy")
            {
                o.GetComponent<MainEnemy>().MainHit(sourceTower.Damage);
                Destroy(this.gameObject);
            }
        }
        else if (o.gameObject == enemy.gameObject)
        {         
           /* if (sourceTower.HitAOE)
            {
                if (o.tag == "Enemy") o.GetComponent<MainEnemy>().MainHit(sourceTower.Damage);               
                Destroy(this.gameObject);
            }*/
            enemy.MainHit(sourceTower.Damage);
            Destroy(this.gameObject);                         
        }
    }
}
