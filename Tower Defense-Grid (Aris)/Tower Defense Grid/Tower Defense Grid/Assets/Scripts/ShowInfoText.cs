using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoText : MonoBehaviour {

	private int i;
	void Start () {
		
	}

	public void displayMessage(int x){
		print("DISPLAY MESSAGE");
		i = x;
		StartCoroutine(disp());
	}

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
		}

		yield return new WaitForSeconds (3);
		this.GetComponent<Text>().text = "";

	}
}
