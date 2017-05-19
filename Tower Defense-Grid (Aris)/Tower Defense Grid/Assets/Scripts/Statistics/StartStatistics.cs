using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStatistics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<StatisticsMenuController> ().ShowStatistics (true);
	}
}
