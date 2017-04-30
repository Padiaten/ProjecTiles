using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy: MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	public void Movement(float coefSpeed,ref Vector2 vectorNext,ref bool flag,ref GameObject g){
		transform.position = Vector2.MoveTowards(transform.position, vectorNext,coefSpeed*Time.deltaTime);
		if (Vector2.Distance((Vector2)transform.position, vectorNext) < 0.1 && !flag) {
			g = g.GetComponent<PathTile>().getNextTile_Random();
			vectorNext = g.GetComponent<Tile>().getCoords();
			if (g.GetComponent<PathTile>().NextTiles.Count == 0)
			{
				flag = true;
			}
		}
		if (Mathf.Approximately(transform.position.x, vectorNext.x) && Mathf.Approximately(transform.position.y, vectorNext.y) && flag)
			Destroy(this.gameObject);
	}
}
//Vector2 dir = new Vector2(vectorNext.x-transform.position.x,vectorNext.y-transform.position.y);
//transform.Translate(speed*Time.deltaTime*dir.normalized,Space.World);