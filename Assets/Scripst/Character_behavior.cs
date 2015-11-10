using UnityEngine;
using System.Collections;

public class Character_behavior : MonoBehaviour {

	public float walkDistance;//distancia que o personagem anda cada vez que a funçao Move() e chamada.

	/*funçoes

	Move(); Movimento do personagem

	*/
	// Use this for initialization
	void Start () {
	
		walkDistance = 1.5f;

	}
	
	// Update is called once per frame
	void Update () {

		Move ();//chama a funçao de movimento do personagem
	}

	//Movimento do personagem
	void Move(){
		if (Game_behaviour.ispaused == 0) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				transform.Translate(-1 * walkDistance, 0,0);
			}
			else if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				transform.Translate(walkDistance, 0,0);
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				transform.Translate(0, -walkDistance,0);
			}
			else if (Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				transform.Translate(0, walkDistance,0);
			}
		}
	}
}
