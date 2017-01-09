using UnityEngine;
using System.Collections;
//using SimpleJSON;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class PlayerDataUtility {
	static readonly PlayerDataUtility instance = new PlayerDataUtility();

	private int score = 0;
}

[Serializable]
class PlayerData {

}