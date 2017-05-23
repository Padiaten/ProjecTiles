using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class GameData{
	//FILE
	private static string filePath;
	//DATA
	private static int difficulty = 0;
	private static int progress = 1;
	private static float musicVolume = 0.5f;
	//μελλοντικα μπορει να δεχτει ακόμα πολλα ακομη στοιχεια οπως towers που εχει αγορασει κ.τ.λ.

	public static void Initialize(){
		Debug.Log ("INITIALIZE DATA");

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


	public static void TransferDataFromFile(){
		Debug.Log ("TRANSFER DATA");
		try 
		{
			AssistantClassGameData acla = new AssistantClassGameData();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Open);
			acla = (AssistantClassGameData)formatter.Deserialize(stream);
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

	public static void Save(){
		Debug.Log ("SAVE DATA");
		try {
			AssistantClassGameData acla = new AssistantClassGameData();
			acla.TransferDataFromGameData();
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream (filePath,FileMode.Truncate);
			formatter.Serialize (stream,acla);
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

[Serializable]
public class AssistantClassGameData{

	private int difficulty = 0;
	private int progress = 1;
	private float musicVolume = 0.5f;

	public AssistantClassGameData(){
	}

	public void Load(){
		GameData.Difficulty = difficulty;
		GameData.Progress = progress;
		GameData.MusicVolume = musicVolume;
	}

	public void TransferDataFromGameData(){
		difficulty = GameData.Difficulty;
		progress = GameData.Progress;
		musicVolume = GameData.MusicVolume;
	}
}
