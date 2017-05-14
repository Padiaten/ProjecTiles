using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public GameObject TT;
    private Tower selectedTower;
    private Projectile p;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = transform.position.z;
        

        if (Input.GetKeyDown(KeyCode.Alpha1)){        
            GameObject TTclone = Instantiate(TT, position, Quaternion.identity) as GameObject;
            TTclone.name = "Tower";
        }
    }

    public void SelectTower(Tower t)
    {
        selectedTower = t;
        selectedTower.Select();
    }
    
}

