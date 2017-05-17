using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class TowerCost{
	private static int cost;
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
}
