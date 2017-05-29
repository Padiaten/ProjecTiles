using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class TowerCost{
	private static int cost,sellvalue;
	//Returns tower cost based on id
	public static int getCost(int i){
		switch(i){
		case 1:
			cost=50;
			break;
		case 2:
			cost=60;
			break;
		case 3:
			cost=125;
			break;
		case 4:
			cost=100;
			break;
		case 5:
			cost=180;
			break;
		case 6:
			cost=200;
			break;
		}

		return cost;
	}

	//Returns tower sell value based on id
	public static int getTowerSellValue(int i,int level){
		int c = getCost(i);
		int lcost =0;
		switch(level){
		case 1:
			lcost = c;
			break;
		case 2:
			lcost = c + (50+(c/2));
			break;
		case 3:
			lcost = c + (50+(c/2)) + (50+(c/3));
			break;
		}
		return (lcost/2);
	}

	//Returns tower upgrade value based on id
	public static int getUpgradeCost(int i,int level){
		int c = getCost(i);
		int lcost =0;
		switch(level){
		case 1:	lcost = c + (c/2);
				break;
		case 2: lcost = c + (c/2) + (c/3);
				break;
		}
		return lcost;
	}

}
