using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
 
public class Enemy: MonoBehaviour {

    [SerializeField]
    private int health;

    [SerializeField]
	private float speed;

    [SerializeField]
    private int worth;

	[SerializeField]
	private int scoreIncrease;

	[SerializeField]
	private int scoreReduction;

	[SerializeField]
	private bool notSlow;

	[SerializeField]
	private int id;
	public int Id{
		set{ id = value; }
	}

    private GameObject gameFlow;   
    private GameObject g;
    private Vector2 vectorNext;
    private bool flag;

    

    // Use this for initialization
    public void Initialize (int i) {
		int diff = GameData.Difficulty;
		if(diff == 1){
			health =(int)(health * 1.2f);
			speed = speed * 1.2f;
		}else if(diff == 2){
			health =(int) (health * 1.5f);
			speed = speed * 1.5f;
			worth =(int)(worth * 0.7f);
		}
		gameFlow = GameObject.Find("GameFlow");
        flag = false;
        List<GameObject> listStarTiles = gameFlow.GetComponent<GridController>().GetStartTiles();
        g = listStarTiles[i].GetComponent<PathTile>().getNextTile_Random();
        vectorNext = g.GetComponent<Tile>().getCoords();
    }


    void Update()
    {
        Movement(speed, ref vectorNext, ref flag, ref g);
    }


    public void Movement(float speed,ref Vector2 vectorNext,ref bool flag,ref GameObject g){

		Vector3 dir = g.transform.position - this.transform.position;
		float angle = (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg)+90;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 20);

		transform.position = Vector2.MoveTowards(transform.position, vectorNext,speed*Time.deltaTime);
		if (Vector2.Distance((Vector2)transform.position, vectorNext) < 0.1 && !flag) {
			g = g.GetComponent<PathTile>().getNextTile_Random();
			vectorNext = g.GetComponent<Tile>().getCoords();
			if (g.GetComponent<PathTile>().NextTiles.Count == 0)
			{
				flag = true;
			}
		}
		if (Mathf.Approximately (transform.position.x, vectorNext.x) && Mathf.Approximately (transform.position.y, vectorNext.y) && flag) {
			EndOfRoute ();
		}
	}

	public void Hit(int damage)
	{
		health -= damage;
		if (health <= 0) {
			KillEnemy ();
		}
	}

	public void EndOfRoute()
	{
		gameFlow.GetComponent<Player> ().Lives--;
		gameFlow.GetComponent<Player> ().UpdateScore ((-scoreReduction));
		gameFlow.GetComponent<Player> ().UpdateHealth();
		gameFlow.GetComponent<Player> ().AddInEnemieList (id,false);
		gameFlow.GetComponent<Player>().ControLives();
		DestroyEnemy();
	}

	public void KillEnemy()
	{
		gameFlow.GetComponent<Player> ().UpdateScore (scoreIncrease);
		gameFlow.GetComponent<Player> ().UpdateGold(worth);
		gameFlow.GetComponent<Player> ().AddInEnemieList (id,true);
		DestroyEnemy();
	}
	
	public void DestroyEnemy()
	{
		Destroy (this.gameObject);
		gameFlow.GetComponent<FlowController> ().NumbersOfEnemies--;
	}

    public void EffectHit(string effect, int value)
    {
		if (!notSlow) {
			if(effect == "Slow")
			{
				speed /= value;
			}
			else if(effect == "Restore Movement")
			{
				speed *= value;
			}
		}
    }
}
//Vector2 dir = new Vector2(vectorNext.x-transform.position.x,vectorNext.y-transform.position.y);
//transform.Translate(speed*Time.deltaTime*dir.normalized,Space.World);