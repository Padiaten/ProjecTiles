using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField]
    private bool hits;

    [SerializeField]
    private bool multipleRoundhouseHit;
    public bool MultipleRoundhouseHit
    {
        get { return multipleRoundhouseHit; }
    }

    [SerializeField]
    private bool hitAOE;
    public bool HitAOE
    {
        get { return hitAOE; }
    }
	
    [SerializeField]
    private float rangeAOE;
	public float RangeAOE{
		get{return rangeAOE;}
		set{rangeAOE = value;}
	}
	
    [SerializeField]
    private int damage;
    public int Damage
    {
        get { return damage; }
		set {damage = value;}
    }

    [SerializeField]
	private float attackCooldown, atkcool;
	public float AttackCooldown {
		get {return attackCooldown;}
		set {attackCooldown = value;
			 atkcool = attackCooldown;}
	}

    [SerializeField]
    private float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
		set {projectileSpeed = value;}
    }

    [SerializeField]
    private string effect;
    public string Effect
    {
        get { return effect; }
    }

    [SerializeField]
	private int effectValue;

	public int EffectValue {
		get {return effectValue;}
		set {effectValue = value;}
	}

    [SerializeField]
    private Projectile projectileObject;

	[SerializeField]
	private int id;
	public int Id{
		get{ return id; }
		set{ id = value; }
	}

	private Enemy enem2;
    public Enemy Enem2
    {
        get { return enem2; }
    }

    private Queue<Enemy> enemies = new Queue<Enemy>();

    private float attackTimer;
    private bool canAttack;

    private Vector2[] vlist = new Vector2[8];
    
	private int TowerLevel = 1;
	public int Towerlevel
    {
		get{ return TowerLevel;}
		set{ TowerLevel = value;}
	}

    private List<Tower> buffedTowers = new List<Tower>();
    private List<Enemy> slowedEnemies = new List<Enemy>();

    // Use this for initialization
    void Start ()
    {
		atkcool = attackCooldown;

        //Δημιουργεί τις κατευθήνσεις των βλημάτων εαν ο πύργος πυροβολάει γύρω γύρω
        if (multipleRoundhouseHit)
        {
            vlist[0] = new Vector2(transform.position.x + 100, transform.position.y);
            vlist[1] = new Vector2(transform.position.x - 100, transform.position.y);
            vlist[2] = new Vector2(transform.position.x, transform.position.y + 100);
            vlist[3] = new Vector2(transform.position.x, transform.position.y - 100);
            vlist[4] = new Vector2(transform.position.x + 100, transform.position.y + 100);
            vlist[5] = new Vector2(transform.position.x + 100, transform.position.y - 100);
            vlist[6] = new Vector2(transform.position.x - 100, transform.position.y + 100);
            vlist[7] = new Vector2(transform.position.x - 100, transform.position.y - 100);
        }
		
		UpdateRange();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hits == true)
        {
            if (!multipleRoundhouseHit && enem2 != null) LookAtTarget();
            Attack();           
        }
    }
     

    /*Ενημερώνει το βεληνεκές του πύργου*/
	public void UpdateRange()
    {
		GetComponent<CircleCollider2D>().radius = 1;
	}

    /*Ορίζει τη συμεριφορά του πύργου κατά την επίθεση*/
    private void Attack()
    {
        //Ελεγχει αν μπορεί να επιτεθεί ο πύργος
        if (!canAttack)
        {
            //Ελέγχει αν ο χρόνος για την επόμενη επίθεσης του πύργου έχει έρθει
            attackTimer += Time.deltaTime;
			if (attackTimer >= atkcool)
            {
                //Δίνει τη δυνατότητα στο πύργο να ρίξει\εμφανίσει το βλήμα
                canAttack = true;
                attackTimer = 0;
				if(transform.parent.name == "Global Tower")
                {
					atkcool = attackCooldown + Random.Range(0f,1f);
				}
            }
        }

        //Αφαιρέι από την ουρά τους εχθρούς που βγήκαν από το βεληνεκές του πύργου
        if (enem2 == null && enemies.Count > 0)
        {
            enem2 = enemies.Dequeue();
        }

        //Ελέγχει αν μπορεί να ρίξει\εμφανίσει το βλήμα στον εχθρο που στοχεύει
        if(enem2 != null && enem2.isActiveAndEnabled && canAttack)
        {
            Shoot();
        }
    }

    /*Δημιουργία του βλήματος*/
    private void Shoot()
    {
        //Φορτώνει το sprite του βλήμματος 
		if(projectileObject == null)
        {
			projectileObject = (Projectile)Resources.Load("Prefabs/Projectiles/Projectile", typeof(Projectile));
		}

        //Προσδιορίζει πως θα δημιουργηθούν τα βλήμματα ανάλογα με το τύπο του πύργου
        if (multipleRoundhouseHit)
        {

            //Δηιουργούνται 8 βλήμματα που στοχεύουν σε 8 διαφορετικές κατευθήνσεις
            Projectile[] proj = new Projectile[8];
            
            for (int i = 0; i < 8; i++)
            {
                proj[i] = Instantiate(projectileObject, this.transform.position, Quaternion.identity) as Projectile;
                proj[i].Initialize(this,vlist[i]);
            }

            canAttack = false;
        }
        else {

            //Δημιουργεί 1 βλήμμα που ακολουθεί τον εχθρό που έχει ορίσει ο πύργος
            Projectile proj = Instantiate(projectileObject, this.transform.position, Quaternion.identity) as Projectile;
            proj.Initialize(this, new Vector2(0,0));

            canAttack = false;
        }
    }

    /*Ανεβάζει τη ζημιά που προκαλεί ο πύργος*/
    public void DamageBuff(int value)
    {
        damage += value;
    }

    /*Κάνει το πύργο να κοιτάει στον εχθρο που στοχεύει*/
    public void LookAtTarget()
    {

        if (enem2 != null)
        {
            Vector3 diff = enem2.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, (rot_z - 90));
        }
    }

  
    /*Η συμπεριφορά του πύργου όταν ένας εχθρός μπαίνει στο βεληνεκές (Collider) του πύργου*/
    public void OnTriggerEnter2D(Collider2D o)
    {
        //Αν είναι εχθρός ενεργοποιείται η παρακάτω διαδικασία
        if (o.tag == "Enemy")
        {   
            //Αν ο πύργος πυροβολάει βάζει στην ουρά τον εχθρό        
            if (hits == true)
            {
                enemies.Enqueue(o.GetComponent<Enemy>());
            }

            //Αν ο πύργος κάνει slow μειώνει τη κίνηση του εχθρού
            if (effect == "Slow")
            {
                o.GetComponent<Enemy>().EffectHit("Slow", effectValue);
                slowedEnemies.Add(o.GetComponent<Enemy>());
            }
        }
        //Αν είναι πύργος ενεργοποιείται η παρακάτω διαδικασία
        if (o.tag == "Tower")
        {
            //Αν ο πύργος ενδυναμώνει τους άλλους πύργους καλεί τη DamageBuff των πύργων που είναι στο βεληνεκές
            if (effect == "DamageBuff")
            {
                o.GetComponentInChildren<Tower>().DamageBuff(effectValue);
                buffedTowers.Add(o.GetComponentInChildren<Tower>());
            }
        }
    }

    /*Η συμπεριφορά του πύργου όταν ένας εχθρός βγαίνει από το βεληνεκές (Collider) του πύργου*/
    public void OnTriggerExit2D(Collider2D o)
    {
        
        if(o.tag == "Enemy")
        {
            if (hits == true)
            {
                if (enemies.Contains(o.GetComponent<Enemy>()))
                {
                    enemies.Dequeue();
                }
                enem2 = null;
            }

            //Αναιρεί τη αλλαγή της κίνησης του εχθρού
            if (effect == "Slow")
            {
                o.GetComponent<Enemy>().EffectHit("Restore Movement", effectValue);
                slowedEnemies.Remove(o.GetComponent<Enemy>());
            }
        }
        else if (o.tag == "Projectile")        
        {
            //Καταστρέφονται τα βλήμματα αν βγουν από το βεληνεκές αν είναι Roundhousehit tower
            if (multipleRoundhouseHit)
                if(o.GetComponent<Projectile>().SourceTower == this)
                    Destroy(o.gameObject);            
        }
    }

    /*Αναιρεί τις επιδράσεις που έχει στα αντικείμεντα αν ο πύργος πουληθεί*/
    public void OnDisable()
    {
        //Αναιρείται η αύξηση στη ζημιά
        if(Effect == "DamageBuff")
            foreach(Tower t in buffedTowers)
            {
                t.DamageBuff(-effectValue);
            }
        //Αναιρείται η μείωση της κίνησης των εχθρών
        else if(Effect == "Slow")       
            foreach(Enemy e in slowedEnemies)
            {
                e.EffectHit("Restore Movement", effectValue);
            }
        
    }
}
