using UnityEngine;
using System.Collections;

public class Game_behaviour : MonoBehaviour {

	public static int ispaused; //variavel de controle do menu de pause
	public static int begin;//indica se o player ja fez o primeiro movimento
	public Rect menu_position;//Posiçao e tamanho da janela de Pause
	public Rect pop_position;//Posiçao e tamanho do pop up de restart
	private int restart;//variavel que controla pop-up de restart
	private int victory;//variavel que diz se o jogo esta vecido ou nao
	public TextMesh Score;//armazena o objeto que printa o tempo
	private float tempo;//contador de tempo
	public AudioSource botao;//arquivo de audio
	private int action;//seletor de açoes

	// Use this for initialization
	void Start () {
		ispaused = 0;//controla quando a janela de pause deve aparecer.
		restart = 0;
		victory = 0;
		tempo = 0;
		begin = 0;
		action = 0;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		Pause ();//chama a funçao Pause.

		if (begin == 1 && action == 0) {
			tempo += Time.deltaTime;
		}
		AddScore(tempo);

	}

	public void AddScore(float newScore){
		Score.text = "Tempo: "+newScore.ToString("f1");
	}

	//User Interface
	void OnGUI()
	{
		if (ispaused == 1) {
			menu_position = new Rect ((Screen.width/2) - 150 ,(Screen.height/2) - 80, 300, 160);//seta a posiçao e o tamanho da janela de pause
			GUI.Window(0,menu_position,pause_menu,"Pause menu");//Abre o menu de Pause.
		}
		if(restart == 1){
			pop_position = new Rect ((Screen.width/2) - 150 ,(Screen.height/2) - 80, 300, 60);//seta a posiçao e o tamanho da janela de pause
			GUI.Window(0,pop_position,restart_pop,"Gostaria mesmo de reiniciar a fase?");//Abre o menu de Pause.
		}
		if(victory == 1){
			pop_position = new Rect ((Screen.width/2) - 150 ,(Screen.height/2) - 80, 300, 90);//seta a posiçao e o tamanho da janela de win
			GUI.Window(0,pop_position,victory_pop,"Voce venceu! Gostaria de jogar novamente?");//Abre o menu de Pause.
		}
	}

	//detecta se a caixa eta no lugar correto.
	void OnCollisionEnter2D(Collision2D objeto) {
		if (objeto.gameObject.tag == "Box")
		{
			Cursor.visible = true;//mostra o mouse
			Time.timeScale = 0;
			victory = 1;
			ApplicationController.AddToRanking (tempo);
			Debug.Log("Bateu!");
			gameObject.GetComponent<AudioSource>().Play();
		}
	}

	//Pausa e despausa o jogo
	void Pause(){

		if (Input.GetKeyDown (KeyCode.Escape) && ispaused == 0 && victory == 0) 
		{
			ispaused = 1;//altera o valor da variavel de controle e abre a janela de pause
			Time.timeScale = 0;//congela todos os itens da tela 'Pausa o jogo'.
			Cursor.visible = true;//mostra o mouse
			Debug.Log ("ispaused = "+ispaused);
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && ispaused == 1 && victory == 0) 
		{
			ispaused = 0;//altera o valor da variavel de controle e fecha a janela de pause
			Time.timeScale = 1;//descongela os itens da tela 'Despausa o jogo'
			Cursor.visible = false;//esconde o mouse
			Debug.Log ("ispaused = "+ispaused);
		}
		else if (Input.GetKeyDown (KeyCode.R) && ispaused == 0 && victory == 0) 
		{
			restart = 1;//altera o valor da variavel de controle e abre o pop up de restart
			Cursor.visible = true;//mostra o mouse
			Time.timeScale = 0;//congela os itens da tela 'Pausa o jogo'
		}
	}

	//Conteudo do menu de pausa
	void pause_menu(int novajanela)
	{
		GUI.FocusWindow (novajanela);//foca a janela de pause
		GUI.backgroundColor = new Color(0,0,0,250f);

		//continua o jogo.
		if (GUI.Button(new Rect(110,30,80,20),"Resume")) {
			Time.timeScale = 1;
			botao.Play();
			ispaused = 0;
			Time.timeScale = 1;
			Cursor.visible = false;//esconde o mouse
		}
		//vai para o menu principal.
		if (GUI.Button(new Rect(110,60,80,20),"Main Menu") || action == 1) {
			if(action == 0)
			{
				action = 1;
				Time.timeScale = 1;
				botao.Play();
			}
			if(!botao.isPlaying)
				Application.LoadLevel("Menu");
		}
		//reinicia o level
		if (GUI.Button(new Rect(110,90,80,20),"Restart")) {			
			botao.Play();
			restart = 1;
		}
		//Sai do jogo
		if (GUI.Button(new Rect(110,120,80,20),"Exit")) {
			botao.Play();
			Application.Quit();
		}

	}

	//conteudo do popup de restart.
	void restart_pop(int novajanela)
	{
		GUI.FocusWindow (novajanela);//foca a janela de restart
		GUI.backgroundColor = new Color(0,0,0,250f);

		if (GUI.Button(new Rect(20,30,80,20),"Sim") || Input.GetKeyDown (KeyCode.Space) || action == 2) {
			if(action == 0)
			{
				Time.timeScale = 1;
				botao.Play();
				action = 2;
			}
			if(!botao.isPlaying)
				Application.LoadLevel("Fase1");
		}
		if (GUI.Button(new Rect(180,30,80,20),"Nao")) {
			restart = 0;
			ispaused = 0;
			Cursor.visible = false;//esconde o mouse
			Time.timeScale = 1;
			botao.Play();
		}
	}

	//conteudo popup de win.
	void victory_pop(int novajanela)
	{
		GUI.FocusWindow (novajanela);//foca a janela de victory
		GUI.backgroundColor = new Color(0,0,0,250f);
		GUI.Label(new Rect(90,21,200,100), "Seu tempo: "+tempo.ToString("f1"));
		GUI.Label(new Rect(83,35,200,100), "Melhor tempo: "+PlayerPrefs.GetFloat("Position"+0).ToString("f1"));

		if (GUI.Button(new Rect(20,60,80,20),"Sim")) {
			Time.timeScale = 1;
			Application.LoadLevel("Fase1");
		}
		if (GUI.Button(new Rect(180,60,80,20),"Nao")) {
			Time.timeScale = 1;
			Application.LoadLevel("Menu");
		}
	}
}
