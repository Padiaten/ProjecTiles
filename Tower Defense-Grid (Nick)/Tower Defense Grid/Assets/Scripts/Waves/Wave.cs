using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject> ();
	private Transform spawnPoint;
	private float timeBetweenEnemies,countdown,oldTiBeEn = 0;
	private int countEnemy,enemyIndex,waveIndex = 0; 
	private List<List<string>> waves = new List<List<string>> ();
	private GameObject gameFlow;
	private bool outWave = true,endWave = false;
	private int starTileIndex;

	public void Initialize(int i)
	{
		starTileIndex = i;
		gameFlow = GameObject.Find("GameFlow");
		spawnPoint = gameFlow.GetComponent<GridController> ().GetStartTiles()[starTileIndex].GetComponent<PathTile>().transform;
		waves = LevelHandler.GetSelectedWave ()[starTileIndex];
	}

	public void next_Wave(){
		StartCoroutine (WaveSpawner());
	}

	IEnumerator WaveSpawner()
	{
		outWave = false;
		if (waveIndex < waves.Count) {
			List<string> wave = waves [waveIndex];
			string item = "", values = "";
			int index, oldindex;
			for (int i = 0; i < wave.Count; i++) {	
				oldindex = 0;
				item = wave [i];
				item.Replace (" ", "");
				index = item.IndexOf ('-');
				values = item.Substring (oldindex, (index - oldindex));
				countdown = float.Parse (values);
				oldindex = index;

				index = item.IndexOf ('-', (index + 1));
				values = item.Substring ((oldindex + 1), (index - oldindex - 1));
				countEnemy = int.Parse (values);
				oldindex = index;

				index = item.IndexOf ('-', (index + 1));
				values = item.Substring ((oldindex + 1), (index - oldindex - 1));
				enemyIndex = int.Parse (values);

				values = item.Substring ((index + 1), (item.Length - index - 1));
				timeBetweenEnemies = float.Parse (values);

				yield return new WaitForSeconds (countdown - oldTiBeEn);
				for (int j = 0; j < countEnemy; j++) {
					CreateEnemy (enemyIndex,spawnPoint,starTileIndex);
					yield return new WaitForSeconds (timeBetweenEnemies);
				}
				oldTiBeEn = timeBetweenEnemies;
			}
			waveIndex++;
			if (waveIndex >= waves.Count) {
				endWave = true;
			}
		}
		outWave = true;
	}

	public void CreateEnemy(int index,Transform point,int starTileIndex)
	{
		GameObject enem = Instantiate (enemies [index], point.position, point.rotation);
		enem.tag = "Enemy";
		enem.GetComponent<Enemy> ().Initialize (starTileIndex);
		gameFlow.GetComponent<FlowController> ().NumbersOfEnemies++;
	}

	public bool OutWave
	{
		get{ return outWave; }
		set{ outWave = value; }
	}

	public bool EndWave{
		get{ return endWave; }
		set{ endWave = value; }
	}
}
