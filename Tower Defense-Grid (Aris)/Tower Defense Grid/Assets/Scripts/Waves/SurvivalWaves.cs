
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//θελει καλο ελεγχο καποιες μικρο αναβαθμισεις και καλυτερο σχολιασμο
//μην ασχοληθει ομως κανεις με αυτην αν δεν με ρωτησει πρωτα
public class SurvivalWaves : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject> ();
	private static int InitiaEnemiesNumber = 5;//με ποσα enemies/κυμα θα ξεκινησει το παιχνιδι 
	private static int EnemyAdder = 5;//ποσα παραπανω enemies θα βγαινουν σε καθε κυμα
	private static float StartPercentage = 0.5f;//αρχικο ποσοστο του dominantEnemy στο κυμα
	private static float EndPercentage = 1.0f;//τελικο ποσοστο του dominantEnemy στο κυμα, προτεινεται να μην παιρνει τιμη μεγαλυτερη απο 1.0f
	// x= EndPercentage-StartPercentage. Αν x > WavesPerEnemy τοτε για x κυματα το percentage θα είναι ισο με EndPercentage
	private static float PercentageAdder = 0.1f;//κατα ποσο αυξανεται το ποσοστο μεσα σε ενα κυμα του dominantEnemy(η αυξηση γινεται ανα κυμα)
	private static int WavesPerEnemy = 5;//σε ποσα κυματα θα ειναι ενα enemy dominantEnemy
	private static List<string> TimeBetweenEnemies = new List<string>{"2-0.1-0.5","2-0.1-0.2","2-1-0.2","1-0.1-0.2","0.1-0.01-0.02","0.05-0.01-0.01"};
	/*η παραπανω λιστα περιεχει τους χρονους μεταξυ των enemies. Ο πρώτος αριθμος αντιστοιχει στον αρχικο χρονο μεταξυ των enemies ο δευτερος στο κατωτατο οριο που μπορει να φτασει
	 * και ο τριτος στο κατα ποσο θα μειωνεται ο χρονος.Για τα κυματα που δεν εχει δηλωθει χρονος θα χρησιμοποιουν το τελευταιο στοιχειο της λιστας. Το προγραμμα θα μετακινειται στο
	 * επομενο στοιχειο της λιστας μετα απο WavesPerTime κυματα
	 */
	private static int WavesPerTime = 5;//μετα απο ποσα κυματα θα αλλαζουν οι χρονοι μεταξυ των enemies
	private static float Start_Random_Perce_OfNum = 0.1f;//αρχικο ποσοστο του κυματος που ο αριθμος του θα ειναι τυχαιος
	private static float Random_Perce_Adder = 0.1f;//ποσο θα αυξανεται το Random_Perce_OfNum
	private static int WavesPerRandomPerce = 10;//ανα ποσα κυματα θα αυξανεται το Random_Perce_OfNum

	private int numberStartiles;
	private int waveIndex = 0;
	private int enemyIndex = 0;
	private int dominantEnemy;//το enemy που θα βγαινει σε μεγαλυτερη αναλογια
	private float percentage;//ποσοστο του dominantEnemy στο κυμα
	private int enemiesNumber;//ποσα enemies θα βγαινουν σε καθε κυμα

	private int dominantEnemiesNumber,otherEnemiesNumber;
	private float subtracter, startTime, endTime;
	private int listOfTimesIndex = 0;
	private int listTimeCount;

	private bool outWave = true;
	private Transform spawnPoint;
	private int starTileIndex = 0; 
	private float timeBetEnemies;
	private GameObject gameFlow;
	private float random_Perce_OfNum;

	void Start (){
		gameFlow = GameObject.Find ("GameFlow");
		numberStartiles = gameFlow.GetComponent<GridController> ().GetStartTiles().Count;//αριθμος εισοδων
		dominantEnemy = enemyIndex;
		percentage = StartPercentage;
		enemiesNumber = InitiaEnemiesNumber;
		listTimeCount = TimeBetweenEnemies.Count;
		random_Perce_OfNum = Start_Random_Perce_OfNum;
		spawnPoint = gameFlow.GetComponent<GridController> ().GetStartTiles()[starTileIndex].GetComponent<PathTile>().transform;
	}

	public void Next_Wave(){
		StartCoroutine (WaveSpawner());
	}

	IEnumerator WaveSpawner()
	{
		outWave = false;
		enemiesNumber -= Mathf.RoundToInt (enemiesNumber * (random_Perce_OfNum - Random.Range (0f,random_Perce_OfNum)));
		dominantEnemiesNumber = Mathf.RoundToInt (enemiesNumber * percentage);
		otherEnemiesNumber = enemiesNumber - dominantEnemiesNumber;

		if (listOfTimesIndex < listTimeCount) {
			if ((waveIndex % WavesPerTime) == 0) {
				ReadData ();
			}
		}

		for(int i=0; i<dominantEnemiesNumber; i++)
		{
			if (numberStartiles > 1) {
				starTileIndex = Mathf.RoundToInt (Random.Range (0,numberStartiles));
				spawnPoint = gameFlow.GetComponent<GridController> ().GetStartTiles()[starTileIndex].GetComponent<PathTile>().transform;
			}
			CreateEnemy (dominantEnemy,spawnPoint,starTileIndex);
			yield return new WaitForSeconds (timeBetEnemies);
		}
		for(int i = 0; i<otherEnemiesNumber; i++)
		{
			if (numberStartiles > 1) {
				starTileIndex = Mathf.RoundToInt (Random.Range (0,numberStartiles));
				spawnPoint = gameFlow.GetComponent<GridController> ().GetStartTiles()[starTileIndex].GetComponent<PathTile>().transform;
			}
			int randomEnemy = Mathf.RoundToInt (Random.Range (0,enemyIndex));
			CreateEnemy (randomEnemy,spawnPoint,starTileIndex);
			yield return new WaitForSeconds (timeBetEnemies);
		}

		enemiesNumber += EnemyAdder;
		if (timeBetEnemies != endTime) {
			timeBetEnemies -= subtracter;
			if (timeBetEnemies < endTime) {
				timeBetEnemies = endTime;
			}
		}
		waveIndex++;//πρωτα να αυξανεται ο waveIndex και μετα να γινονται οι παρακατω ελεγχοι αλλιως αν αυξανεται μετα θα αλλαζει το dominantEnemy ενα κυμα αργοτερα
		/*ο παρακατω ελεγχος να γινεται αφου εχει αυξηθει το waveIndex αλλιως οταν θα ειναι 0 η συνθηκη θα ειναι αληθης
		 * πραγμα το οποιο δεν το θελουμε
		 */ 
		if ((waveIndex % WavesPerEnemy) == 0) {
			percentage = StartPercentage;
			if (enemyIndex < (enemies.Count - 1)) {
				enemyIndex++;
				dominantEnemy = enemyIndex;
			}
		}
		if ((percentage + PercentageAdder) < EndPercentage) {
			percentage += PercentageAdder;
		} else
			percentage = EndPercentage;
		if((waveIndex % WavesPerRandomPerce) == 0){
			random_Perce_OfNum += Random_Perce_Adder;
		}
		outWave = true;
		//if(waveIndex >= 30)
	}

	public void ReadData()
	{
		int index,oldindex = 0;
		string values = "";
		string item = TimeBetweenEnemies[listOfTimesIndex].Replace(" ","");

		index = item.IndexOf ('-');
		values = item.Substring (oldindex, (index - oldindex));
		startTime = float.Parse (values);
		oldindex = index;

		index = item.IndexOf ('-', (index + 1));
		values = item.Substring ((oldindex + 1), (index - oldindex - 1));
		endTime = float.Parse (values);

		values = item.Substring ((index + 1), (item.Length - index - 1));
		subtracter = float.Parse (values);

		print (startTime+"-"+endTime+"-"+subtracter);

		timeBetEnemies = startTime;
		listOfTimesIndex++;
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
}
