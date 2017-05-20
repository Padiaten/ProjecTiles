using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultySetter{

	private static int Difficulty = 0;

	public static void setDifficulty(int i){
		Difficulty = i;
	}

	public static int getDifficulty(){
		return Difficulty;
	}

}
