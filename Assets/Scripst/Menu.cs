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
		gameObject.GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Fase1");
	}
	public void Exit(){
		gameObject.GetComponent<AudioSource>().Play();
		Application.Quit ();
	}
	public void Menu_principal()
	{
		gameObject.GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Menu");
	}
	public void Credits()
	{
		gameObject.GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Credits");
	}
	public void Ranking()
	{
		gameObject.GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Ranking");
	}
}
