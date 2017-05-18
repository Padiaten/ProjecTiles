using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityEngine.Object[] enemiesList = Resources.LoadAll ("Prefabs/Enemies",typeof(GameObject));
		int length = enemiesList.Length;
		GameObject g;
		for (int i = 0; i < length; i++) {
			g = enemiesList [i] as GameObject;
			g.GetComponent<Enemy> ().Id = i;
		}

		UnityEngine.Object[] towersList = Resources.LoadAll ("Prefabs/Towers",typeof(GameObject));
		length = towersList.Length;
		for (int i = 0; i < length; i++) {
			g = towersList [i] as GameObject;
			g.GetComponentInChildren<Tower> ().Id = i;
		}
	}
}
