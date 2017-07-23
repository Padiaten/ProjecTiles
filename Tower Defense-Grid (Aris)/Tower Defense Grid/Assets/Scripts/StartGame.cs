using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Καλείται όταν αρχίζει το παιχνίδι. Κάνει κάποιες βασικές ενέργειες προτού ξεκινήσει το παιχνίδι όπως 
να καλέσει τις συναρτήσεις των αντίστοιχων κλάσεων για την μεταφορά των δεδομένων από τα αρχεία στις κατάλληλες μεταβλητές*/
public class StartGame : MonoBehaviour {

	private static bool initial = false;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		if (!initial) {
			/*ΠΡΟΣΟΧΗ WARNING !!! η σειρά με την οποία καλούνται οι συναρτήσεις αν πρέπει να αλλάξει να γίνεται με πολύ προσοχή 
			διότι μπορεί κάποια συνάρτηση να χρειάζεται κάποια δεδομένα από μία ενέργεια που έχει εκτελεστεί πιο πριν από αυτήν*/
			panel.SetActive (false);
			GameData.Initialize ();
			UnityEngine.Object[] enemiesList = Resources.LoadAll ("Prefabs/Enemies", typeof(GameObject));
			int length = enemiesList.Length;
			GameObject g;
			for (int i = 0; i < length; i++) {
				g = enemiesList [i] as GameObject;
				g.GetComponent<Enemy> ().Id = i;
			}

			UnityEngine.Object[] towersList = Resources.LoadAll ("Prefabs/Towers", typeof(GameObject));
			length = towersList.Length;
			for (int i = 0; i < length; i++) {
				g = towersList [i] as GameObject;
				g.GetComponentInChildren<Tower> ().Id = i;
			}
				
			StatisticsData.Initialize ();

			GameObject.Find ("Loading").SetActive (false);
			panel.SetActive (true);
			initial = true;
		}
	}
}
