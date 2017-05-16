using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private bool roundhouseF = false;

    private Vector3 direction;

	private Enemy enem;
    private Tower sourceTower;

    private BoxCollider2D bCol;
    private CircleCollider2D cCol;

    private List<Enemy> damagedEnemies;

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
        enem = sourceTower.Enem2;
        direction = dir;
    }

    void MovetoEnemy()
    {
        if (enem != null && enem.isActiveAndEnabled)
        {

            Vector3 diff = enem.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            transform.position = Vector3.MoveTowards(transform.position, enem.transform.position,
                                                     Time.deltaTime * sourceTower.ProjectileSpeed);
        }
        else if (enem == null)
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
                o.GetComponent<Enemy>().Hit(sourceTower.Damage);
                Destroy(this.gameObject);
            }
        }
        else if (o.gameObject == enem.gameObject)
        {         
           /* if (sourceTower.HitAOE)
            {
                if (o.tag == "Enemy") o.GetComponent<Enemy>().Hit(sourceTower.Damage);               
                Destroy(this.gameObject);
            }*/
            enem.Hit(sourceTower.Damage);
            Destroy(this.gameObject);                         
        }
    }
}
