using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLockedLevelMessage : MonoBehaviour {

	//Calls show,cannot be called directly
	public void disp(){
		StartCoroutine(show());
	}

	IEnumerator show(){

		this.GetComponent<Text>().text = "LOCKED LEVEL";
		yield return new WaitForSeconds (3);
		this.GetComponent<Text>().text = "";

	}
}
