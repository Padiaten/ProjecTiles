using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {

	public void ChangeDiff(){
		GameData.Difficulty = (int)this.GetComponent<Slider> ().value;
	}
}
