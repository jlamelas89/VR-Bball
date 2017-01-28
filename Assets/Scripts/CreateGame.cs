using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;

public class CreateGame : MonoBehaviour {
	bool matchCreated;
	NetworkMatch matchMaker;
	NetworkManager networkManager;

	void Start () {
		networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
		SetGazedAt(false);
	}

	void LateUpdate() {
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void CreateInternetMatch(string matchName){
		networkManager.matchMaker.CreateMatch (matchName, 4, true, "", "", "", 0, 0, OnInternetMatchCreate);
	}

	private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo) {
		if (success) {
			MatchInfo hostInfo = matchInfo;
			NetworkServer.Listen (hostInfo, 7777);

			networkManager.StartHost(hostInfo);
			print ("create match succeeded");
			print (matchInfo);
		} 
		else {
			Debug.LogError ("Create match failed");
		}
	}

	public void FindInternetMatch(string matchName) {
		networkManager.matchMaker.ListMatches (0, 10, matchName, true, 0, 0, OnInternetMatchList);
	}

	private void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches) {
		if (success) {
			if (matches.Count != 0) {
				networkManager.matchMaker.JoinMatch (matches [matches.Count - 1].networkId, "", "", "", 0, 0, OnJoinInternetMatch);
			} 
			else {
				Debug.Log ("No matches in requested room!");
			}
		} 
		else {
			Debug.LogError ("Couldn't connect to match maker");
		}
	}

	private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		if (success) {
			MatchInfo hostInfo = matchInfo;
			networkManager.StartClient (hostInfo);
			print ("match joined");
		} 
		else {
			Debug.LogError ("join match failed");
		}
	}

	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
	}

		
	#if !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
	//	public void ToggleDirectRender() {
	//		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
	//	}
	#endif  //  !UNITY_HAS_GOOGLEVR || UNITY_EDITOR

	#region IGvrGazeResponder implementation

	public void OnGazeEnter() {
		SetGazedAt(true);
		//		print ("sjdfid");
	}

	public void OnGazeExit() {
		SetGazedAt(false);
	}

	public void OnGazeTrigger() {
//		MainMenu();
		networkManager.StartMatchMaker ();
		this.enabled = false;
		if (this.name == "Multi Player") {
			CreateInternetMatch ("match1");
		} 
		else if (this.name == "Options") {
			FindInternetMatch ("match1");
		}
//		print ("test");
	}

	#endregion
}
