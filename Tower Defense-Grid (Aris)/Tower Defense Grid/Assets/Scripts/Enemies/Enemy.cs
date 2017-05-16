using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour {

    [SerializeField]
    private int health;

    [SerializeField]
    private float coefSpeed;

   // private float cStemp;

    [SerializeField]
    private int worth;

    private GameObject gameFlow;   
    private GameObject g;
    private Vector2 vectorNext;
    private bool flag;

    

    // Use this for initialization
    public void Initialize (int i) {
		gameFlow = GameObject.Find("GameFlow");
        flag = false;
        List<GameObject> listStarTiles = gameFlow.GetComponent<GridController>().GetStartTiles();
        g = listStarTiles[i].GetComponent<PathTile>().getNextTile_Random();
        vectorNext = g.GetComponent<Tile>().getCoords();
    }


    void Update()
    {
        Movement(coefSpeed, ref vectorNext, ref flag, ref g);
    }


    public void Movement(float coefSpeed,ref Vector2 vectorNext,ref bool flag,ref GameObject g){

		Vector3 dir = g.transform.position - this.transform.position;
		float angle = (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg)+90;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 20);

		transform.position = Vector2.MoveTowards(transform.position, vectorNext,coefSpeed*Time.deltaTime);
		if (Vector2.Distance((Vector2)transform.position, vectorNext) < 0.1 && !flag) {
			g = g.GetComponent<PathTile>().getNextTile_Random();
			vectorNext = g.GetComponent<Tile>().getCoords();
			if (g.GetComponent<PathTile>().NextTiles.Count == 0)
			{
				flag = true;
			}
		}
		if (Mathf.Approximately (transform.position.x, vectorNext.x) && Mathf.Approximately (transform.position.y, vectorNext.y) && flag) {
			gameFlow.GetComponent<Player> ().Lives--;
			gameFlow.GetComponent<Player>().ControLives();
			gameFlow.GetComponent<Player> ().UpdateHealth();
			DestroyEnemy();
			/* πρωτα ενημερωνω lives και μετα καλω την DestroyEnemy αλλιως σε περιπτωση που ο παικτης εχει π.χ. 1 ζωη και ενας εχθρος φτασει
			 * στο τελος λογικα το παιχνιδι θα πρεπει να τερματιστει καθως ο παικτης θα εχει χασει. Αν ομως καλεσω πρωτα την DestroyEnemy 
			 * το παιχνιδι θα καταλαβει οτι συμπληρωθηκε το level καθως θα καλεστει πρωτα η ControlNumOfEnemies(βλεπε πως λειτουργει στο FlowController)
			 * και οχι μονο αυτο αλλα θα εμφανιστει στην συνεχεια και η οθονη gameOver
			 */ 
		}
	}

	public void Hit(int damage)
	{
		health -= damage;
		if (health <= 0) {
			gameFlow.GetComponent<Player> ().Kill++;
			gameFlow.GetComponent<Player> ().Money += worth;
			gameFlow.GetComponent<Player> ().UpdateGold();
			DestroyEnemy();
		}
        
	}
	
	public void DestroyEnemy()
	{
		Destroy (this.gameObject);
		gameFlow.GetComponent<FlowController> ().NumbersOfEnemies--;
		gameFlow.GetComponent<FlowController> ().ControlNumOfEnemies();
	}

    public void EffectHit(string effect, int value)
    {

        if(effect == "Slow")
        {
            coefSpeed /= value;
        }
        else if(effect == "Restore Movement")
        {
            coefSpeed *= value;
        }
    }
}
//Vector2 dir = new Vector2(vectorNext.x-transform.position.x,vectorNext.y-transform.position.y);
//transform.Translate(speed*Time.deltaTime*dir.normalized,Space.World);