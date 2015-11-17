using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Play(){
		Application.LoadLevel ("Fase1");
	}
	void Exit(){
		Application.Quit ();
	}
	void Menu_principal()
	{
		Application.LoadLevel ("Menu");
	}
}
