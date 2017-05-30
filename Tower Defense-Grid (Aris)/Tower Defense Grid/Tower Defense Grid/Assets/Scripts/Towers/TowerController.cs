using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour {

	public GameObject TowerMenu, InfoMessage;
	private GameObject SelectedTower = null;
	private int ttype,tlevel;

	void Start(){
		InfoMessage = GameObject.Find("InfoMessage");
	}

	void Update(){

        //Επιλέγεται ο πύργος με το αριστερό κλικ κ εκτελείται η SelectTower
		if(Input.GetMouseButtonDown(0))
        {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
			if(hit.collider != null && hit.collider.tag == "Tower")
				SelectTower(hit.collider.gameObject);
		}
	}


	public void SelectTower(GameObject t)
    {
		if(SelectedTower != null)
        {
            //Εμφανίζει το μενου των tower (Upgrade Tower, Sell Tower)
			SelectedTower.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			TowerMenu.transform.Find("UpgradeButton").GetComponentInChildren<Text>().text = "";
			TowerMenu.transform.Find("SellButton").GetComponentInChildren<Text>().text = "";
		}

        //Κάνει εμφανες στο χρήστη οτι επίλέχτηκε ο πύργος
		SelectedTower = t;
		SelectedTower.GetComponent<SpriteRenderer>().color = new Color(1f,0,0,1f);
		tlevel = SelectedTower.GetComponentInChildren<Tower>().Towerlevel;

        //Ορίζει μια int ανάλογα με το τύπο του πύργου
		switch(t.name){
		case "Tower":ttype = 1;
		break;
		case "Slow Tower":ttype = 2;
		break;
		case "Buff Tower":ttype = 3;
		break;
		case "RoundHouse Tower":ttype = 4;
		break;
		case "Global Tower":ttype =5;
		break;
		case "Canon Tower":ttype =6;
		break;
		}

        //Προσδιορίζει τις αναβαθμίσεις των πύργων
		TowerUpgrades.setTowerUpgrades(ttype,tlevel);
		ToggleTowerMenu();
		UpdateMenu();
    }

    //Ενεργοποιείται το μενού των πύργων
	public void ToggleTowerMenu()
    {
		TowerMenu.SetActive(true);
	}
    
    //Οριίζει το κείμενο στα κουμπια του μένού των πύργων
	public void UpdateMenu()
    {
		TowerMenu.transform.Find("UpgradeButton").GetComponentInChildren<Text>().text = "UPGRADE(" + TowerCost.getUpgradeCost(ttype,tlevel) + ")";
		TowerMenu.transform.Find("SellButton").GetComponentInChildren<Text>().text = "SELL(" + TowerCost.getTowerSellValue(ttype,tlevel) + ")";
	}

    //Αναβάθμιση πύργου
	public void UpgradeTower()
    {
		int cost = TowerCost.getUpgradeCost(ttype,tlevel);
		if(this.GetComponent<Player>().Money >= cost)
        {
			if(tlevel < 3)
            {
				SelectedTower.GetComponentInChildren<Tower>().Towerlevel = tlevel + 1;

                //Γίνεται η αφαίρεση των χρημάτων για την αναβάθμιση και 
				this.GetComponent<Player>().UpdateGold(-cost);

                //Eνημερώνονται οι μεταβλητές για τις ιδιότητες του πύργου
                int damage;
				float atk_cool;
				float proj_sp;
				int eff_val;
				float range;

				damage = TowerUpgrades.Damage;
				atk_cool = TowerUpgrades.Atk_cool;
				proj_sp = TowerUpgrades.Proj_sp;
				eff_val = TowerUpgrades.Eff_val;
				range = TowerUpgrades.Range;

				if(damage != 0)     SelectedTower.GetComponentInChildren<Tower>().Damage = damage;
				
				if(atk_cool != 0)   SelectedTower.GetComponentInChildren<Tower>().AttackCooldown = atk_cool;

				if(proj_sp != 0)	SelectedTower.GetComponentInChildren<Tower>().ProjectileSpeed = proj_sp;

				if(eff_val != 0)    SelectedTower.GetComponentInChildren<Tower>().EffectValue = eff_val;
			

				if(range != 0)
                {
					SelectedTower.transform.Find("Range").transform.localScale = new Vector3(range,range,1);
					SelectedTower.GetComponentInChildren<Tower>().UpdateRange();
				}

				CancelTowerMenu();
			}

            else	InfoMessage.GetComponent<ShowInfoText>().displayMessage(4);

		}

	}

    //Εξαφανίζει το μενού των πύργων
	public void CancelTowerMenu()
    {
		TowerMenu.SetActive(false);
		SelectedTower.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		SelectedTower = null;
	}

    //Γίνεται η πώληση του πύργου
	public void SellTower()
    {
		int value = TowerCost.getTowerSellValue(ttype,tlevel);
		this.GetComponent<Player>().UpdateGold(value);

        //Απελευθερώνει το tile που ήταν ο πύργος
		int x = (int)SelectedTower.transform.position.x;
		int y = (int) SelectedTower.transform.position.y;
		string tilename = "G " + x + "," + y;
        GameObject.Find(tilename).GetComponent<GrassTile>().setCanPlaceBuilding(true);

        //Αφαιρείται ο πύργος από το παιχνίδι
        GetComponent<Player>().AddInTowerList(SelectedTower.GetComponentInChildren<Tower>().Id,false);
		Destroy(SelectedTower);
		CancelTowerMenu();
	}
}

