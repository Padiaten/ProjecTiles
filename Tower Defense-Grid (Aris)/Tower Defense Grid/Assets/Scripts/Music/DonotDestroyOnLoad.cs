using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonotDestroyOnLoad : MonoBehaviour {
	private bool muted;
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
			this.GetComponent<AudioSource>().volume = 0;

		}else{
			GameObject.Find("Music").GetComponent<Image>().sprite = (Sprite)Resources.Load("Sprites/GUI/b_Sound1",typeof(Sprite));
			this.GetComponent<AudioSource>().volume = 1;

		}
	}
		
	public bool getMuted(){
		return muted;
	}

	public void setMuted(bool m){
		muted = m;
	}
}
