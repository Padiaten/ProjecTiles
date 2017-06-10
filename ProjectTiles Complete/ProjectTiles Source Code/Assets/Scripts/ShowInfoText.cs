using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoText : MonoBehaviour {

	private int i;

	//Calls disp(Cannot be called directly)
	public void displayMessage(int x){
		i = x;
		StartCoroutine(disp());
	}

	//Displays a message on a UIText object for 3 seconds
	IEnumerator disp(){
		switch(i){
		case 1:
			this.GetComponent<Text>().text = "Cannot place on path";
			break;
		case 2:
			this.GetComponent<Text>().text = "Cannot place on occupied tile";
			break;
		case 3:
			this.GetComponent<Text>().text = "Insufficient funds";
			break;
		case 4:
			this.GetComponent<Text>().text = "Max Level";
			break;
		}

		yield return new WaitForSeconds (3);
		this.GetComponent<Text>().text = "";

	}
}
