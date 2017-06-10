using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private bool roundhouseF = false;

    private Vector3 direction;

	private Enemy enem;
    private Tower sourceTower;
    public Tower SourceTower
    {
        get { return sourceTower; }
    }

    private List<Enemy> damagedEnemies;

    // Use this for initialization
    void Start() {	
        if(sourceTower != null)
             roundhouseF = sourceTower.MultipleRoundhouseHit;
    }

    // Update is called once per frame
    void Update() {
        if (roundhouseF) Move();
        else MovetoEnemy();
    }

    /*Αρχικοποιεί τον πύργο από τον οποίο προέρχεται το βλήμα και τη κατεύθηνση του*/
    public void Initialize(Tower sourceTower, Vector2 dir)
    {
        this.sourceTower = sourceTower;
        enem = sourceTower.Enem2;
        direction = dir;
    }

    /*Η κίνηση του βλήμματος προς τον εχθρό που στοχεύει ο πύργος*/
    void MovetoEnemy()
    {
        //Κυνηγάει τον εχθρό εαν υπάρχει ακόμη
        if (enem != null && enem.isActiveAndEnabled)
        {
            Vector3 diff = enem.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            transform.position = Vector3.MoveTowards(transform.position, enem.transform.position,
                                                     Time.deltaTime * sourceTower.ProjectileSpeed);
        }
        //Καταστρέφει το βλήμα αν έχει καταστραφεί ο εχθρός που στοχεύει
        else if (enem == null)
        {
            Destroy(this.gameObject);
        }
    }

    /*Η κίνηση του βλήμματος αν έχει κατεύθηνση διαφορετική από Vector2(0,0)*/
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * sourceTower.ProjectileSpeed);
    }

    /*Οι επιπτώσεις που έχει το βλήμμα όταν συγρούεται με εχθρό*/
    public void OnTriggerEnter2D(Collider2D o)
    {
        //Αν ο πυργος είναι Roundhouse εκετελείται η παρακάτω διαδικασία
        if (sourceTower.MultipleRoundhouseHit)
        {
            if(o.tag == "Enemy")
            {
                o.GetComponent<Enemy>().Hit(sourceTower.Damage);
                Destroy(this.gameObject);
            }
        }
        //Αν το βλήμμα συγκρουστεί με τον εχθρό που έχει στοχεύσει ο πύργος εκετελείτα η παρακάτω διαδικασία
        else if (o.gameObject == enem.gameObject)
        {  
            //Αν το βλήμα κάνει ζημιά σε μία περιοχή εκτελείται η παρακάτω διαδικασία
            if (sourceTower.HitAOE)
            {	
                //Εντοπίζει τους εχθρους που είναι μέσα στη περιοχή που κάνει ζημια το βλήμμα
				Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position,sourceTower.RangeAOE);
				foreach(Collider2D en in enemies){
					if(en.gameObject.tag == "Enemy"){
						en.gameObject.GetComponent<Enemy>().Hit(sourceTower.Damage);
					}
				}
			}
            else
            {
				enem.Hit(sourceTower.Damage);
			}
            Destroy(this.gameObject);                         
        }
    }
}
