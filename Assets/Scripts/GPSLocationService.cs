using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class GPSLocationService : MonoBehaviour {

	private GameObject GPSTextObj;
	private Text GPSText;

	void Start() 
	{
		GPSTextObj = GameObject.Find("GPSText");
		GPSText = GetComponent<Text> ();
//		GPSTextObj.GetComponent<Text> ().text = "putting gps here";
		StartCoroutine (StartGPS());
	
	}

	IEnumerator StartGPS() 
	{
//		print ("test");
//		yield return new WaitForSeconds (1);

		if (!Input.location.isEnabledByUser)
			GPSTextObj.GetComponent<Text> ().text = "Not Enabled";
			yield break;
//
		Input.location.Start ();

		int maxWait = 1;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
		{
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		if (maxWait < 1) 
		{
			GPSTextObj.GetComponent<Text> ().text = "Timed Out";
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			GPSTextObj.GetComponent<Text> ().text = "Failed";
			yield break;
		} 
		else 
		{
//			"Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp
			GPSTextObj.GetComponent<Text> ().text = Input.location.lastData.latitude.ToString();
		}
		Input.location.Stop ();

	}
}
