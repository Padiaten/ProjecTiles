using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

//Διαχειρίζεται τα δεδομένα του παιχνιδιού 
public static class GameData{
	//FILE
	private static string filePath;
	//DATA
	private static int difficulty = 0;
	private static int progress = 1;//μέχρι ποιο level έχει ξεκλειδώσει
	private static float musicVolume = 0.5f;
	//μελλοντικα μπορει να δεχτει πολλα ακομη στοιχεια οπως towers που εχει αγορασει κ.τ.λ.

	public static void Initialize(){
		string directoryPath = System.IO.Directory.GetCurrentDirectory() + "\\Saves";
		filePath = directoryPath + "\\savedData.svd";

		//ψαξε τον φακελο
		if (System.IO.Directory.Exists(directoryPath)) {//τον βρηκες
			//υπαρχει το αρχειο;
			if (System.IO.File.Exists (filePath)) {
				Stream stream = new FileStream (filePath, FileMode.Open);
				int b = stream.ReadByte ();
				stream.Close ();
				if (b != -1) {//αν το αρχείο δεν έιναι κενο
					TransferDataFromFile ();//μετεφερε τα δεδομενα στις μεταβλητες
				}
			} else {
				System.IO.File.Create (filePath);
			}
			
		} else {//δεν τον βρήκες
			//δημιουργησε φακελο κι αρχειο και βάλε στις τιμες 0
			System.IO.Directory.CreateDirectory(directoryPath);
			System.IO.File.Create (filePath);
		}
	}

	//Μεταφορά των δεδομένων από το αρχείο
	public static void TransferDataFromFile(){
		try 
		{
			AssistantClassGameData acla = new AssistantClassGameData();//δημιουργία αντικειμένου από την βοηθητικη κλάση
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Open);
			acla = (AssistantClassGameData)formatter.Deserialize(stream);//αποσειριοποίηση
			stream.Close ();
			acla.Load();
		}
		catch(Exception e)
		{
			Debug.Log("Exception: " + e.Message);
		}
		finally 
		{
			Debug.Log("Executing finally block.");
		}
	}

	//Αποθήκευση των δεδομένων
	public static void Save(){
		try {
			AssistantClassGameData acla = new AssistantClassGameData();//δημιουργία αντικειμένου από την βοηθητικη κλάση
			acla.TransferDataFromGameData();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Truncate);
			formatter.Serialize (stream,acla);//σειριοποίηση
			stream.Close ();
		}
		catch(Exception e)
		{
			Debug.Log("Exception: " + e.Message);
		}
		finally 
		{
			Debug.Log("Executing finally block.");
		}
	}

	public static int Difficulty{
		get{ return difficulty; }
		set{ difficulty = value; }
	}

	public static int Progress {
		get { return progress; }
		set { progress = value; }
	}

	public static float MusicVolume{
		get{ return musicVolume; }
		set{ musicVolume = value ;}
	}
}

/*βοηθητική κλάση. Χρησιμοποιείται διότι η GameData λόγω του ότι είναι στατική δεν γίνεται να σειριοποιηθεί
*υπηρχε και άλλος τρόπος για την αποθηκευση της αλλά έπρεπε όλα τα πεδία της να γίνουν public οπότε προτίμησα αυτόν
*τραβάει ουσιαστικά όλες τις τιμές από την GameData σειριοποιείται και αποθηκεύεται
*όταν "αποσειριοποιηθεί" περνάει τις τιμές της στην GameData
*/
[Serializable]
public class AssistantClassGameData{

	private int difficulty = 0;
	private int progress = 1;
	private float musicVolume = 0.5f;

	public AssistantClassGameData(){
	}

	//μεταφορά των τιμών των πεδίων της στα πεδία της GameData. Είναι το αντίστροφο της TransferDataFromGameData
	public void Load(){
		GameData.Difficulty = difficulty;
		GameData.Progress = progress;
		GameData.MusicVolume = musicVolume;
	}

	//μεταφορα των δεδομένων από την GameData στα δικά της πεδία
	public void TransferDataFromGameData(){
		difficulty = GameData.Difficulty;
		progress = GameData.Progress;
		musicVolume = GameData.MusicVolume;
	}
}
