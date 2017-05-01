using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy: MonoBehaviour {

	private GameObject gameFlow;

	// Use this for initialization
	protected void Start () {
		print("yea started boi");
		gameFlow = GameObject.Find("GameFlow");
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
			Destroy (this.gameObject);

			gameFlow.GetComponent<FlowController> ().Lives--;
		}
	}

	public void MainHit(int hitpoints,int health,int worth)
	{
		health -= hitpoints;
		if (health <= 0) {
			Destroy (this.gameObject);
			gameFlow.GetComponent<FlowController> ().Kill++;
			gameFlow.GetComponent<FlowController> ().Money += worth;
		}
	}
}
//Vector2 dir = new Vector2(vectorNext.x-transform.position.x,vectorNext.y-transform.position.y);
//transform.Translate(speed*Time.deltaTime*dir.normalized,Space.World);