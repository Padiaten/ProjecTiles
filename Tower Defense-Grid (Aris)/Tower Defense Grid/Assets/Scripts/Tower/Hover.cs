using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    bool canPlace, f;
    SpriteRenderer childSR;

    // Use this for initialization
    void Start () {
        canPlace = true;
        f = true;
        childSR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        childSR.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

        //Τοποθέτηση Πύργων
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = transform.position.z;

        if (Input.GetMouseButtonUp(0) && canPlace)
        {
            f = false;
            childSR.enabled = false;
        }
        if (f) transform.position = Vector2.Lerp(transform.position, position, 1f);

    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Tower") canPlace = false;
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Tower") canPlace = true;
    }

}
