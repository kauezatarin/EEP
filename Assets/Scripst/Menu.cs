using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private int action;

	// Use this for initialization
	void Start () {
		action = 0;
	}
	void Update() {

		if (action == 1 && !gameObject.GetComponent<AudioSource>().isPlaying)
		{
			Application.LoadLevel ("Fase1");
		}
		if (action == 2 && !gameObject.GetComponent<AudioSource>().isPlaying)
		{
			Application.Quit ();
		}
		if (action == 3 && !gameObject.GetComponent<AudioSource>().isPlaying)
		{
			Application.LoadLevel ("Menu");
		}
		if (action == 4 && !gameObject.GetComponent<AudioSource>().isPlaying)
		{
			Application.LoadLevel ("Credits");
		}
		if (action == 5 && !gameObject.GetComponent<AudioSource>().isPlaying)
		{
			Application.LoadLevel ("Ranking");
		}


	}
	public void Play(){
		gameObject.GetComponent<AudioSource>().Play();
		action = 1;
	}
	public void Exit(){
		gameObject.GetComponent<AudioSource>().Play();
		action = 2;
	}
	public void Menu_principal()
	{
		gameObject.GetComponent<AudioSource>().Play();
		action = 3;
	}
	public void Credits()
	{
		gameObject.GetComponent<AudioSource>().Play();
		action = 4;
	}
	public void Ranking()
	{
		gameObject.GetComponent<AudioSource>().Play();
		action = 5;
	}
}
