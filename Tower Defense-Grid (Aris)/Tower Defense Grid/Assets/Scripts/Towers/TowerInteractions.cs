using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInteractions : MonoBehaviour {

	//When the mouse hovers over tower,show range
	public void OnMouseEnter(){
		if(this.name != "Global Tower"){
			Color c = transform.Find("Range").GetComponentInChildren<SpriteRenderer>().color;
			transform.Find("Range").GetComponentInChildren<SpriteRenderer>().color =  new Color(c.r,c.g,c.b,100/255f);
		}
	
	}

	//When the mouse stops hovering over tower,hide range
	public void OnMouseExit(){
		Color c = transform.Find("Range").GetComponentInChildren<SpriteRenderer>().color;
		transform.Find("Range").GetComponentInChildren<SpriteRenderer>().color = new Color(c.r,c.g,c.b,0);;

	}



}
