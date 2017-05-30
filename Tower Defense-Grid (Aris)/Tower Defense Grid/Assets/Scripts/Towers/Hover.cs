using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Το αντικείμενο του πύργου πριν τοποθετηθεί στο χάρτη*/

public class Hover : MonoBehaviour {

	bool hovering = true;
	private GameObject InfoMessage;

	private int towerCost;
    // Use this for initialization
    void Start () {        
		GetComponentInChildren<CircleCollider2D>().enabled = false;
        GetComponentInChildren<BoxCollider2D>().enabled = false;
		transform.Find("Range").GetComponent<SpriteRenderer>().enabled = false;

		InfoMessage = GameObject.Find("InfoMessage");
    }

    // Update is called once per frame
    void Update() {

        //Τοποθέτηση Πύργων
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));

        if (hovering) {


            //Περιορίζει τη θέση του πύργου στα όρια του χάρτη
            if (position.x < 0) 
                position.x = 0;
            else if (position.x > LevelHandler.getDimX() - 1)
                position.x = LevelHandler.getDimX() - 1;
            

            if (position.y < 0)
                position.y = 0;
            else if (position.y > LevelHandler.getDimY() - 1)
                position.y = LevelHandler.getDimY() - 1;
            

            transform.position = position;

            //Αριστερό κλικ για τη τποθέτηση
            if (Input.GetMouseButtonDown(0)) {

                string Pname_test = "P " + position.x + "," + position.y;
                string Gname_test = "G " + position.x + "," + position.y;
                //Μύνημα για τη λάθος τοποθέτηση πάνω στο μονοπάτι των εχθρών
                if (GameObject.Find(Pname_test))
                    InfoMessage.GetComponent<ShowInfoText>().displayMessage(1);

                //Μύνημα για τη λάθος τοποθέτηση πάνω στο μονοπάτι των εχθρών
                else if (GameObject.Find(Gname_test).GetComponent<GrassTile>().getCanPlaceBuilding() == false)
                    InfoMessage.GetComponent<ShowInfoText>().displayMessage(2);

                //Μύνημα για ανεπαρκής χρήματα για την αγορά του πύργου
                else if (GameObject.Find("GameFlow").GetComponent<Player>().Money < towerCost)
                    InfoMessage.GetComponent<ShowInfoText>().displayMessage(3);
                                    
                //Τοποθέτηση πύργου στο χάρτη απενεργοποιόντας τη λειτουργία αυτού του script
				else
                {
                        GameObject.Find("GameFlow").GetComponent<Player>().AddInTowerList(this.gameObject.GetComponentInChildren<Tower>().Id, true);
                        GameObject.Find("GameFlow").GetComponent<Player>().UpdateGold((-towerCost));
                        GameObject.Find(Gname_test).GetComponent<GrassTile>().setCanPlaceBuilding(false);
                        GetComponentInChildren<CircleCollider2D>().enabled = true;
                        GetComponentInChildren<BoxCollider2D>().enabled = true;
                        transform.Find("Range").GetComponent<SpriteRenderer>().enabled = true;
                        GetComponentInChildren<Tower>().enabled = true;
                        GetComponent<TowerInteractions>().enabled = true;
                        hovering = false;
                        this.GetComponent<Hover>().enabled = false;
                }
            }
                //Ακύρωση τοποθέτησης με το δεξί κλικ
            if (Input.GetMouseButtonDown(1))
            {
                print("Cancelled");
                hovering = CancelPlacement();
            }
        }
    }


    //Ορίζει το κόστος του πύργου
	public void setTowerCost(int i){
		towerCost = i;
	}

    //Ακυρώνει την αγορά του πύργου
	public bool CancelPlacement(){
		Destroy(this.gameObject);
		return false;
	}
}
