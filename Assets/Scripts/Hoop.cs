using UnityEngine;
using System.Collections;

public class Hoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position += new Vector3(.05f, 0, 0);
	}

	void OnTriggerEnter() 
	{
		print ("hi");
	}

//	IEnumerator MoveFunction()
//	{
//		float timeSinceStarted = 0f;
//		while (true)
//		{
//			timeSinceStarted += Time.DeltaTime;
//			obj.transform.position = Vector3.Lerp(obj.transform.position, newPosition, timeSinceStarted);
//
//			// If the object has arrived, stop the coroutine
//			if (obj.transform.position == newPosition)
//			{
//				yield break;
//			}
//
//			// Otherwise, continue next frame
//			yield return null;
//		}
//	}
}
