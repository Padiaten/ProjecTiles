using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class GameData{
	//FILE
	private static string filePath;
	//DATA
	private static int difficulty = 0;
	//pistes ξεκλειδωμενες κ.τ.λ.
	private static int progress = 1;

	public static void Initialize(){
		string directoryPath = System.IO.Directory.GetCurrentDirectory() + "\\Saves";
		filePath = directoryPath + "\\savedData.sv";

		//ψαξε τον φακελο
		if (System.IO.Directory.Exists(directoryPath)) {//τον βρηκες
			//υπαρχει το αρχειο;
			if (System.IO.File.Exists (filePath)) {
				StreamReader sr = new StreamReader(filePath);
				string line = sr.ReadLine ();
				sr.Close ();
				if(line != null)//αν το αρχείο δεν έιναι κενο
					TransferDataFromFile ();//μετεφερε τα δεδομενα στις μεταβλητες
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
		string line;
		try 
		{
			//Pass the file path and file name to the StreamReader constructor
			StreamReader sr = new StreamReader(filePath);

			difficulty = int.Parse(sr.ReadLine());
			//int.Parse(sr.ReadLine()) warning int,float,string
			//close the file
			sr.Close();
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
		try {

			//Pass the filepath and filename to the StreamWriter Constructor
			StreamWriter sw = new StreamWriter(filePath);

			sw.WriteLine(difficulty);
			/*sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();
			sw.WriteLine();*/


			//Close the file
			sw.Close();
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
		set{ 
			difficulty = value; 
			Save ();
		}
	}

	public static int Progress {
		get {
			return progress;
		}
		set {
			progress = value;
		}
	}
}
