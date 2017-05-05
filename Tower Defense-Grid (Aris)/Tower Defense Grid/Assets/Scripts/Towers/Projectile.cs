using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private bool AOEDamage;

    [SerializeField]
    private float radius;

    private MainEnemy enemy;
    private Tower sourceTower;

    private BoxCollider2D bCol;
    private CircleCollider2D cCol;

    private List<MainEnemy> damagedEnemies;

	// Use this for initialization
	void Start () {
        bCol = GetComponent<BoxCollider2D>();
        cCol = GetComponent<CircleCollider2D>();

        if (AOEDamage == true)
            cCol.radius = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        MovetoEnemy();
	}

    public void Initialize(Tower sourceTower)
    {
        this.sourceTower = sourceTower;    
        enemy = sourceTower.Enemy;
    }

    void MovetoEnemy()
    {
        if(enemy!=null && enemy.isActiveAndEnabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, 
                                                     Time.deltaTime * sourceTower.ProjectileSpeed);

            Vector2 dir = enemy.transform.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (enemy == null)
        {
            Destroy(this.gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D o)
    {

        if (o.gameObject == enemy.gameObject)
        {
            if (AOEDamage == true)
            {
                foreach (var e in damagedEnemies)
                {
                    e.MainHit(sourceTower.Damage);

                }
                Destroy(this.gameObject);
            }
            else
            {
                enemy.MainHit(sourceTower.Damage);
                Destroy(this.gameObject);
            }
        }
            /*if (o == cCol)
            {
                if (AOEDamage == true)
                {
                    if (o.tag == "Enemy") damagedEnemies.Add(o.GetComponent<MainEnemy>());
                }
            }*/       
    }

    /*public void OnTriggerExit2D(Collider2D o)
    {
        if (o == cCol)
        {
            if (AOEDamage == true)
            {
                if (o.tag == "Enemy") damagedEnemies.Remove(o.GetComponent<MainEnemy>());
            }
        }
    }*/
}
