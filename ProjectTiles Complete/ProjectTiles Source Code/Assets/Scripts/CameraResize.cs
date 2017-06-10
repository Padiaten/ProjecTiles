using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour {

	//Resizes camera so that the map and the UI are properly positioned
	void Start () {
		float h = (float)LevelHandler.getDimY();
		Camera.main.GetComponent<Camera>().orthographicSize = h/2;
		Camera.main.transform.position = new Vector3((h/2)-0.5f-((1.332f*h-h)/2),(h/2)-0.5f,transform.position.z); 
		print("DimY" + LevelHandler.getDimY());
	}

}
