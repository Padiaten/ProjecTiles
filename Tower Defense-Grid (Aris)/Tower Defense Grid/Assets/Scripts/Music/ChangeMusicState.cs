using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicState : MonoBehaviour {

	//Sets correct sprite on volume object on top right of the menu
	void Start(){
		if(GameObject.Find("BackgroundMusic").GetComponent<DonotDestroyOnLoad>().getMuted()){
			GameObject.Find("Music").GetComponent<Image>().sprite =  (Sprite)Resources.Load("Sprites/GUI/b_Sound1_Inactive",typeof(Sprite));
		}

	}

	//Calls muted
	public void MusicState(){
		GameObject.Find("BackgroundMusic").GetComponent<DonotDestroyOnLoad>().Muted();
	}
}
