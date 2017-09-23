using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class DataManager {
	private static Dictionary<string,string> localization;
	private static Dictionary<string,object> constants;
	private static Dictionary<string, AsteroidData> Asteroids;

	private static string systemLanguage;
	private static bool initialized;

	public static void Init() {
		if(!initialized) {
			systemLanguage = Application.systemLanguage.ToString();
			Debug.LogFormat("System Language: {0}",systemLanguage);

			initialized = true;
		}
	}

	public static IEnumerator DownloadData(string tab, Action<string[]> callback) {
		WWW sheet = new WWW("https://docs.google.com/spreadsheets/d/12pbFm3rRxdCNylDfmV9awVR8ec28cthLVwBsWHRDfcg/export?format=csv&id=12pbFm3rRxdCNylDfmV9awVR8ec28cthLVwBsWHRDfcg&gid=" + tab);

		while(!sheet.isDone)
			yield return null;

		Debug.Log(sheet.text);

		string[] rows = sheet.text.Split('\n');
		callback(rows);
	}

	public static void ProcessLocalization(string[] rows) {
		string[] languages = rows[0].Split(',');

		int languageIndex = 0;

		for(int i = 1;i < languages.Length;i++) {
			if(languages[i] == systemLanguage) {
				languageIndex = i;
				break;
			}
		}

		localization = new Dictionary<string, string>();

		for(int i = 1;i < rows.Length;i++) {
			string[] row = rows[i].Split(',');
			string key = row[0];
			string value = row[languageIndex];

			localization.Add(key,value);
		}
	}

	public static void ProcessAsteroids(string[] rows) {
		
		Asteroids = new Dictionary<string, AsteroidData>();

		for(int i = 1;i < rows.Length;i++) {
			string[] column = rows[i].Split(',');
			string key = column[0];
			string speed = column[1];
			string rotation = column[2];
			string rotation2 = column[3];

			AsteroidData data = new AsteroidData ();
			data.Speed = float.Parse (speed);
			data.Rotation = float.Parse (rotation);
			data.Rotation2 = float.Parse (rotation2);

			Asteroids.Add(key,data);
		}
	}



	public static string LocalizeString(string key) {
		if (localization.ContainsKey (key)) {
			return localization [key];
		} else {
			Debug.Log ("key not found" + key);
			return "";
		}
	}

	public static AsteroidData GetAsteroidData (string key) {
		return Asteroids[key];
	}
	public static void ProcessConstants(string[] rows) {
		constants = new Dictionary<string, object>();

		for(int i = 1;i < rows.Length;i++) {
			string[] row = rows[i].Split(',');
			string key = row[0];
			string type = row[1];

			if(type == "INT") {
				int value = Int32.Parse(row[2]);
				constants.Add(key,value);
			} else if(type == "FLOAT") {
				float value = float.Parse(row[2]);
				constants.Add(key,value);
			} else {
				constants.Add(key,row[2]);
			}
		}
	}

	public static T GetConstant<T>(string key) {
		T value = (T)constants[key];
		return value;
	}
}


public class AsteroidData {
	public float Speed;
	public float Rotation;
	public float Rotation2;
}

