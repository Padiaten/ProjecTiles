using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveControler : MonoBehaviour {
	public GameObject Wave;
	private GameObject gameFlow;
	private bool endOfWaves = true;
	private bool outOfWaves;
	private int wavesIndex;
	private int numOfStartiles;
	private bool createWaves = false;
	private List<GameObject> WaveObjects = new List<GameObject>();

	//Use this for initialization
	void Start()
	{
		numOfStartiles = GetComponent<GridController> ().GetStartTiles().Count;
		gameFlow = GameObject.Find("GameFlow");

		for(int i=0; i<numOfStartiles; i++)
		{
			WaveObjects.Add (Instantiate(Wave) as GameObject);
			WaveObjects [i].name = "Wave_"+i;
			WaveObjects [i].GetComponent<Wave> ().Initialize (i);
		}
		createWaves = true;
	}

	public void callWave()
	{
		GameObject.Find("WaveText").GetComponent<WaveTextController>().updateText(wavesIndex+1);
		for(int i=0; i<numOfStartiles; i++)
		{
			WaveObjects [i].GetComponent<Wave> ().next_Wave();
		}
		wavesIndex++;
	}

	//GETTERS
	public bool EndOfWaves
	{
		get{
			if (createWaves) {
				endOfWaves = true;
				for (int i = 0; i < numOfStartiles; i++) {
					endOfWaves = WaveObjects [i].GetComponent<Wave> ().EndWave && endOfWaves;
				}
				return endOfWaves;
			} else
				return false;
		}
	}

	public bool OutOfWaves{
		get{ 
			outOfWaves = true;
			for(int i=0; i<numOfStartiles; i++)
			{
				outOfWaves = WaveObjects [i].GetComponent<Wave> ().OutWave && outOfWaves;
			}
			return outOfWaves;
		}
	}

	public int WavesIndex{
		get{ return wavesIndex; }
	}
}