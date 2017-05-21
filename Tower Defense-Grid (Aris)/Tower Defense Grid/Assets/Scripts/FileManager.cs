using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
//na mhn jexaso na energopoihsv ta save kai intializw************************************************************
public class FileManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*string directoryPath = System.IO.Directory.GetCurrentDirectory() + "\\Saves";
		string filePath = directoryPath + "\\dokimi.bin";


		if (System.IO.Directory.Exists(directoryPath)) {//τον βρηκες
			//υπαρχει το αρχειο;
			if (System.IO.File.Exists (filePath)) {
				StreamReader sr = new StreamReader(filePath);
				string line = sr.ReadLine ();
				sr.Close ();
				if(line != null)//αν το αρχείο δεν έιναι κενο
			} else {
				System.IO.File.Create (filePath);
			}
		} else {//δεν τον βρήκες
			//δημιουργησε φακελο κι αρχειο και βάλε στις τιμες 0
			System.IO.Directory.CreateDirectory(directoryPath);
			System.IO.File.Create (filePath);
		}

		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream (filePath,FileMode.Truncate);
		formatter.Serialize (stream,new StatisticsData());
		stream.Close ();*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
