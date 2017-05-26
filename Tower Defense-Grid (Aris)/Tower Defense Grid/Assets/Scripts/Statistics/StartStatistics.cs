using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStatistics : MonoBehaviour {

	//χρησιμοποιείται για να "ξεκινάει" το script StatisticsMenuController όταν μπαίνει στην οθόνη Statistics
	void Start () {
		GetComponent<StatisticsMenuController> ().ShowStatistics (true);
	}
}
