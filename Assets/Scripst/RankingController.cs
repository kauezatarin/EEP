using UnityEngine;
using System.Collections;

public class RankingController : MonoBehaviour {

	public TextMesh scoreDisplay;

	// Use this for initialization
	void Start () {
		scoreDisplay.text = "";

		float[] tempRanking = ApplicationController.GetRanking ();

		for (int i=0; i<=ApplicationController.numberPositionRanking-1; i++) {
			scoreDisplay.text += tempRanking[i].ToString("f1");
			scoreDisplay.text += "\n";
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.R))
		{
			ApplicationController.ResetRanking(2);
			Application.LoadLevel("Ranking");
		}

	}
}
