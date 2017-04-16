using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Movement enemy;
    private Tower sourceTower;

	// Use this for initialization
	void Start () {
        
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
        }
    }

    public void OnTriggerEnter2D(Collider2D o)
    {
        if (o.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
