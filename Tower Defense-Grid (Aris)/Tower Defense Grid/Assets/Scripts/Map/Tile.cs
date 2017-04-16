using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour {


	public enum TileType{Grass,Sea,PathStraight,PathCorner,PathTShape,PathCrossroad};

	protected int x,y;
	protected TileType Ttype;
    protected bool canPlaceTower = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initializeTile(int x,int y){
		transform.position = new Vector2(x,y);
		this.x = x;
		this.y = y;
	}

	public int getX(){
		return x;
	}

	public int getY(){
		return y;
	}

	public Vector2 getCoords(){
		Vector2 v = new Vector2(x,y);
		return v;
	}

    public void set_canPlaceTower(bool t)
    {
        canPlaceTower = t;
    }

    public bool getcanPlaceTower()
    {
        return canPlaceTower;
    }
}
