using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float h = (float)LevelHandler.getDimY();
		Camera.main.GetComponent<Camera>().orthographicSize = h/2;
		Camera.main.transform.position = new Vector3((h/2)-0.5f-((1.6f*h-h)/2),(h/2)-0.5f,transform.position.z); 
		print("DimY" + LevelHandler.getDimY());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
