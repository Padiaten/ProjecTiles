using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControler : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject> ();
	private Transform spawnPoint;
	private List<List<string>> waves = new List<List<string>>();

	private float timeBetweenEnemies;
	private float countdown;
	private int countEnemy; 
	private int waveIndex = 0;
	private int enemyIndex;
	private float oldTiBeEn = 0;

	private bool outWave = true;

	void Start()
	{
		List<GameObject> startTiles = GetComponent<GridController> ().GetStartTiles();
		spawnPoint = startTiles [0].GetComponent<PathTile> ().transform;

		waves.Add (new List<string>(){"1-100-1-1","1-3-1-1","1-3-2-1","1-3-3-1","1-3-4-1"});
		waves.Add (new List<string>(){"3-2-0-3","3-3-4-3","3-1-2-3"});
		waves.Add (new List<string>(){"2-3-4-1","2-3-4-2","3-5-3-3"});
		/*waves.Add (new List<string>(){"---","---","---"});
		waves.Add (new List<string>(){"---","---","---"});
		waves.Add (new List<string>(){"---","---","---"});
		waves.Add (new List<string>(){"---","---","---"});*/
	}

	public void callWave()
	{
		StartCoroutine (next_Wave ());
	}

	IEnumerator next_Wave()
	{
		outWave = false;
		if (waveIndex < waves.Count) {
			List<string> wave = waves [waveIndex];
			string item = "",values = "";
			int index,oldindex;
			for(int i=0; i<wave.Count; i++)
			{	
				oldindex = 0;
				item = wave [i];
				item.Replace (" ","");
				index = item.IndexOf ('-');
				values = item.Substring (oldindex,(index-oldindex));
				countdown = float.Parse(values);
				oldindex = index;

				index = item.IndexOf ('-',(index+1));
				values = item.Substring ((oldindex+1), (index-oldindex-1));
				countEnemy = int.Parse (values);
				oldindex = index;

				index = item.IndexOf ('-',(index+1));
				values = item.Substring ((oldindex+1), (index-oldindex-1));
				enemyIndex = int.Parse (values);

				values = item.Substring ((index+1), (item.Length-index-1));
				timeBetweenEnemies = float.Parse (values);


				yield return new WaitForSeconds(countdown-oldTiBeEn);
				for (int j = 0; j < countEnemy; j++) {
					Instantiate (enemies[enemyIndex],spawnPoint.position,spawnPoint.rotation).tag = "Enemy";
					yield return new WaitForSeconds(timeBetweenEnemies);
				}
				oldTiBeEn = timeBetweenEnemies;
			}
			waveIndex++;
		}
		outWave = true;
	}

	public bool OutWave
	{
		get{ return outWave;}
		set{ outWave = value;}
	}
}