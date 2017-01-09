using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class Rim : MonoBehaviour {

	private GameObject scoreObj;
	private int score = 0; // pull score from player data
	private Text scoreText;

	private Transform papa;

	// Use this for initialization
	void Start () {
		scoreObj = GameObject.Find("Score");
		scoreText = GetComponent<Text> ();

		papa = transform.parent;
//		print (scoreObj.GetComponent<Text> ().text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() //if ball hits basket collider
	{
		score += 1;
		scoreObj.GetComponent<Text> ().text = score.ToString ();

		/* TRANSFER TO HOOP.CS */

		float newX = Random.Range (-1.5f, 1.5f);
		float newY = papa.transform.position.y;
		float newZ = Random.Range (4.0f, 5.0f);

		Vector3 newPos = new Vector3(newX, newY, newZ);
		StartCoroutine(MoveHoop(papa.transform.position, newPos));

//		papa.transform.position = newPos;

//		print ("score");
//		int currentScore = int.Parse(score.GetComponent().text) + 1; //add 1 to the score
//		score.GetComponent().text = currentScore.ToString();
//		AudioSource.PlayClipAtPoint(basket, transform.position); //play basket sound
	}

	IEnumerator MoveHoop(Vector3 currentPos, Vector3 newPos)
	{
		float t = 0.0f;

		while (t < .15f) {
			papa.transform.position = Vector3.Lerp (currentPos, newPos, t / .15f);
			yield return null;
			t += Time.deltaTime;
		}

		yield break;
	}
}
