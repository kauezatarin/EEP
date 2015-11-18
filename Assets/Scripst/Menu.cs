using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Play(){
		Application.LoadLevel ("Fase1");
	}
	public void Exit(){
		Application.Quit ();
	}
	public void Menu_principal()
	{
		Application.LoadLevel ("Menu");
	}
	public void Credits()
	{
		Application.LoadLevel ("Credits");
	}
}
