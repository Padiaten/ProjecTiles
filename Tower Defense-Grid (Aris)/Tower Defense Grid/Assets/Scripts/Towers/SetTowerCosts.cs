using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTowerCosts : MonoBehaviour {

	//Sets the tower cost displays on the menu
	void Start () {

		for(int i=1;i<7;i++){
			string towername = "Tower " + i;
			GameObject.Find(towername).transform.Find("Cost").GetComponent<Text>().text = TowerCost.getCost(i).ToString();
		}

	}

}
