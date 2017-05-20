using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class TowerCost{
	private static int cost,sellvalue;
	public static int getCost(int i){
		switch(i){
		case 1:
			cost=50;
			break;
		case 2:
			cost=60;
			break;
		case 3:
			cost=70;
			break;
		case 4:
			cost=80;
			break;
		case 5:
			cost=90;
			break;
		case 6:
			cost=100;
			break;
		}

		return cost;
	}

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
