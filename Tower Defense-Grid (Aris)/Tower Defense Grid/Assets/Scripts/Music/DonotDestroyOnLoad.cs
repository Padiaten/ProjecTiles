using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonotDestroyOnLoad : MonoBehaviour {
	bool muted;
	void Update(){
		print(muted);
		if(muted)
			AudioListener.volume = 0;
			else
			AudioListener.volume = 1;
	}
	void Awake(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("backroundmusic");
		if(objs.Length > 1)
			Destroy (this.gameObject);
		DontDestroyOnLoad(this.gameObject);

	}

	 public void Muted()
	{
		muted = !muted;
		if(muted){
			GameObject.Find("Music").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/b_Sound1_Inactive",typeof(Sprite));
		}else{
			GameObject.Find("Music").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/b_Sound1",typeof(Sprite));
		}
}

	public bool getMuted(){
		return muted;
	}
}
