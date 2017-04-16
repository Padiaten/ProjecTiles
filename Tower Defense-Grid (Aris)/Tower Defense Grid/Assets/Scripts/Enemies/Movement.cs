using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private float speed;
	private GameObject g;
	private GameObject g1;
	private Vector2 vectorEnemy;
	private Vector2 vectorNext;
	private Vector2 v2;

    private bool flag;

	// Use this for initialization
	void Start () {
		vectorEnemy = transform.position;
		speed = 1f;
        List<GameObject> go = Camera.main.GetComponent<GridController>().GetStartTiles();
        g = go[0];
		g = g.GetComponent<PathTile> ().getNextTile_Random ();
		vectorNext = g.GetComponent<Tile> ().getCoords ();
	}
	
	// Update is called once per frame
	void Update () {
            //Vector2 dir = new Vector2(vectorNext.x-transform.position.x,vectorNext.y-transform.position.y);
            //transform.Translate(3*Time.deltaTime*dir.normalized,Space.World);
            transform.position = Vector2.MoveTowards(transform.position, vectorNext,3*Time.deltaTime);
        if (Vector2.Distance((Vector2)transform.position, vectorNext) < 0.2 && !flag) {
            g = g.GetComponent<PathTile>().getNextTile_Random();
            vectorNext = g.GetComponent<Tile>().getCoords();
            if (g.GetComponent<PathTile>().NextTiles.Count == 0)
            {
                print("TRUE");
                flag = true;
            }
        }
        if (Mathf.Approximately(transform.position.x, vectorNext.x) && Mathf.Approximately(transform.position.y, vectorNext.y) && flag)
            Destroy(this.gameObject);
	}
}
