using UnityEngine;
using System.Collections;


public class Game_behaviour : MonoBehaviour {

	public static int ispaused; //variavel de controle
	public Rect menu_position;//Posiçao e tamanho da janela de Pause


	// Use this for initialization
	void Start () {
		ispaused = 0;//controla quando a janela de pause deve aparecer.
	}
	
	// Update is called once per frame
	void Update () {
		Pause ();//chama a funçao Pause.
	}
	//User Interface
	void OnGUI()
	{
		if (ispaused == 1) {
			menu_position = new Rect ((Screen.width/2) - 150 ,(Screen.height/2) - 80, 300, 160);//seta a posiçao e o tamanho da janela de pause
			GUI.Window(0,menu_position,janela,"Pause menu");//Abre o menu de Pause.
		}
	}

	//Pausa e despausa o jogo
	void Pause(){

		if (Input.GetKeyDown (KeyCode.Escape) && ispaused == 0) 
		{
			ispaused = 1;//altera o valor da variavel de controle e abre a janela de pause
			Time.timeScale = 0;//congela todos os itens da tela 'Pausa o jogo'.
			Debug.Log ("ispaused = "+ispaused);
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && ispaused == 1) 
		{
			ispaused = 0;//altera o valor da variavel de controle e fecha a janela de pause
			Time.timeScale = 1;//descongela os itens da tela 'Despausa o jogo'
			Debug.Log ("ispaused = "+ispaused);
		}
	}

	//Conteudo do menu de pausa
	void janela(int novajanela)
	{
		GUI.FocusWindow (novajanela);//foca a janela de pause
		GUI.backgroundColor = new Color(0,0,0,250f);

		//continua o jogo.
		if (GUI.Button(new Rect(110,30,80,20),"Resume")) {
			Time.timeScale = 1;
			ispaused = 0;
			Time.timeScale = 1;
		}
		//vai para o menu principal.
		if (GUI.Button(new Rect(110,60,80,20),"Main Menu")) {
			Time.timeScale = 1;
			Application.LoadLevel("Menu");
		}
		//reinicia o level
		if (GUI.Button(new Rect(110,90,80,20),"Restart")) {
			Time.timeScale = 1;
			Application.LoadLevel("Fase1");
		}
		//Sai do jogo
		if (GUI.Button(new Rect(110,120,80,20),"Exit")) {
			Application.Quit();
		}

	}
}
