using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour {

	public GameObject TowerMenu;
	private GameObject SelectedTower = null;
	private int ttype,tlevel;
	private GameObject InfoMessage;

	void Start(){
		InfoMessage = GameObject.Find("InfoMessage");
	}

	//Checks if a tower is clicked,opens upgrade menu
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
			if(hit.collider != null && hit.collider.tag == "Tower"){
				SelectTower(hit.collider.gameObject);
			}
		}
	}

	//Finds tower type,calls UpdateMenu
	public void SelectTower(GameObject t)
    {
		if(SelectedTower != null){
			SelectedTower.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			TowerMenu.transform.Find("UpgradeButton").GetComponentInChildren<Text>().text = "";
			TowerMenu.transform.Find("SellButton").GetComponentInChildren<Text>().text = "";
		}
		SelectedTower = t;
		SelectedTower.GetComponent<SpriteRenderer>().color = new Color(1f,0,0,1f);
		tlevel = SelectedTower.GetComponentInChildren<Tower>().Towerlevel;

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

		TowerUpgrades.setTowerUpgrades(ttype,tlevel);
		ToggleTowerMenu();
		UpdateMenu();
    }


	//Toggles tower menu
	public void ToggleTowerMenu(){
		TowerMenu.SetActive(true);
	}
    

	//Gets tower upgrade value,sell value and sets the correct labels on buttons
	public void UpdateMenu(){
		TowerMenu.transform.Find("UpgradeButton").GetComponentInChildren<Text>().text = "UPGRADE(" + TowerCost.getUpgradeCost(ttype,tlevel) + ")";
		TowerMenu.transform.Find("SellButton").GetComponentInChildren<Text>().text = "SELL(" + TowerCost.getTowerSellValue(ttype,tlevel) + ")";

	}

	//Handles tower upgrading
	public void UpgradeTower(){
		int cost = TowerCost.getUpgradeCost(ttype,tlevel);
		if(this.GetComponent<Player>().Money >= cost){
			if(tlevel < 3){
				SelectedTower.GetComponentInChildren<Tower>().Towerlevel = tlevel + 1;
				this.GetComponent<Player>().UpdateGold(-cost);
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

				if(damage != 0){
					SelectedTower.GetComponentInChildren<Tower>().Damage = damage;
				}

				if(atk_cool != 0){
					SelectedTower.GetComponentInChildren<Tower>().AttackCooldown = atk_cool;
				}

				if(proj_sp != 0){
					SelectedTower.GetComponentInChildren<Tower>().ProjectileSpeed = proj_sp;
				}

				if(eff_val != 0){
					SelectedTower.GetComponentInChildren<Tower>().EffectValue = eff_val;
				}
			
				if(range != 0){
					SelectedTower.transform.Find("Range").transform.localScale = new Vector3(range,range,1);
					SelectedTower.GetComponentInChildren<Tower>().UpdateRange();
				}

				CancelTowerMenu();
			}else{
				InfoMessage.GetComponent<ShowInfoText>().displayMessage(4);
			}
		}

	}

	//Hides tower upgrade menu
	public void CancelTowerMenu(){

		TowerMenu.SetActive(false);
		SelectedTower.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		SelectedTower = null;

	}

	//Handles tower selling
	public void SellTower(){
		int value = TowerCost.getTowerSellValue(ttype,tlevel);
		this.GetComponent<Player>().UpdateGold(value);
		int x = (int)SelectedTower.transform.position.x;
		int y = (int) SelectedTower.transform.position.y;
		string tilename = "G " + x + "," + y;
		GameObject.Find(tilename).GetComponent<GrassTile>().setCanPlaceBuilding(true);
		GetComponent<Player> ().AddInTowerList (SelectedTower.GetComponentInChildren<Tower>().Id,false);
		Destroy(SelectedTower);
		CancelTowerMenu();
	}
}

