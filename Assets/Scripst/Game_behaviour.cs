using UnityEngine;
using System.Collections;

public class Game_behaviour : MonoBehaviour {

	public static int ispaused;

	// Use this for initialization
	void Start () {
		ispaused = 0;//determina se o jogo esta pausado ou nao
	}
	
	// Update is called once per frame
	void Update () {
		Pause ();//chama a funçao Pause.
	}
	//Pausa e despausa o jogo
	void Pause(){
	
		if (Input.GetKeyDown (KeyCode.P) && ispaused == 0) 
		{
			ispaused = 1;
			Debug.Log ("ispaused = "+ispaused);
		}
		else if (Input.GetKeyDown (KeyCode.P) && ispaused == 1) 
		{
			ispaused = 0;
			Debug.Log ("ispaused = "+ispaused);
		}
	}
}
