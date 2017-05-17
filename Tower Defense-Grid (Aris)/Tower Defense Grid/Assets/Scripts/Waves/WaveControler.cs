using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveControler : MonoBehaviour {
	public GameObject Wave;
	public GameObject SurvivalWave;
	private bool endOfWaves = true;
	private bool outOfWaves;
	private int wavesIndex;
	private int numberStartiles;
	private bool createWaves = false;
	private List<GameObject> WaveObjects = new List<GameObject>();

	private bool survival;

	//Use this for initialization
	void Start()
	{
		survival = LevelHandler.IsSurvival;
		numberStartiles = GetComponent<GridController> ().GetStartTiles ().Count;
		if (!survival) {
			for (int i = 0; i < numberStartiles; i++) {
				WaveObjects.Add (Instantiate (Wave) as GameObject);
				WaveObjects [i].name = "Wave_" + i;
				WaveObjects [i].GetComponent<Wave> ().Initialize (i);
			}
			createWaves = true;
		} else {
			WaveObjects.Add (Instantiate (SurvivalWave) as GameObject);
			WaveObjects [0].name = "SurvivalWave";
		}
	}

	public void callWave()
	{
		GameObject.Find ("WaveText").GetComponent<WaveTextController> ().updateText (wavesIndex + 1);
		if (!survival) {
			for (int i = 0; i < numberStartiles; i++) {
				WaveObjects [i].GetComponent<Wave> ().next_Wave ();
			}
		} else {
			WaveObjects [0].GetComponent<SurvivalWaves> ().Next_Wave ();
		}
		wavesIndex++;
	}

	//GETTERS
	public bool EndOfWaves
	{
		get{
			if (createWaves) {
				endOfWaves = true;
				for (int i = 0; i < numberStartiles; i++) {
					endOfWaves = WaveObjects [i].GetComponent<Wave> ().EndWave && endOfWaves;
				}
				return endOfWaves;
			} else
				return false;
		}
	}

	public bool OutOfWaves{
		get{ 
			if (!survival) {
				outOfWaves = true;
				for (int i = 0; i < numberStartiles; i++) {
					outOfWaves = WaveObjects [i].GetComponent<Wave> ().OutWave && outOfWaves;
				}
				return outOfWaves;
			} else {
				return WaveObjects [0].GetComponent<SurvivalWaves> ().OutWave;
			}
		}
	}

	public List<GameObject> ListWithEnemies
	{
		get
		{ 
			if (!survival)
				return WaveObjects [0].GetComponent<Wave> ().EnemiesList;
			else
				return WaveObjects [0].GetComponent<SurvivalWaves> ().EnemiesList;
		}
	}

	public int WavesIndex{
		get{ return wavesIndex; }
	}
}