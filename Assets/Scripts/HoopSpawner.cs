using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HoopSpawner : NetworkBehaviour {
	private GameObject hoopPrefab, hoop;

	// Use this for initialization
	public override void OnStartServer () {
		hoopPrefab = (GameObject)Resources.Load ("Objects/Network Prefabs/Hoop", typeof(GameObject));
		Quaternion rotation = Quaternion.Euler (0.0f, 90f, 0.0f);

		hoop = (GameObject)Instantiate (hoopPrefab, this.transform.position, rotation);

		NetworkServer.Spawn (hoop);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
