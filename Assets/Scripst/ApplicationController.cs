using UnityEngine;
using System.Collections;

public class ApplicationController : MonoBehaviour {

	public static int numberPositionRanking = 5;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (gameObject);

		Application.LoadLevel ("Menu");
	}
	
	public static void AddToRanking(float tempo){
		float[] tempRanking = GetRanking ();
		int positionScore = -1;

		/*for(int i =0; i<numberPositionRanking; i++)
			PlayerPrefs.SetFloat("Position"+i, 100f);*/

		for (int i=0; i<numberPositionRanking; i++) {
			if(tempo < tempRanking[i])
			{
				positionScore = i;
			}
			if(positionScore > -1)
			{
				float oldTime = tempRanking[positionScore];

				PlayerPrefs.SetFloat("Position"+positionScore, tempo);
		
				AddToRanking(oldTime);
			}
		}

	}

	public static float[] GetRanking(){

		float[] tempRanking = new float [numberPositionRanking];

		for (int i=0; i<numberPositionRanking; i++) {
			if(PlayerPrefs.HasKey("Position"+i))//verifica se existe registros no HD. utiliza a classe PlayerPrefs para ler e armazenar no HD
			{
				tempRanking[i] = PlayerPrefs.GetFloat("Position"+i);//Resgata o que esta armazenado no HD.
				if(tempRanking[i] == 0)
				{
					tempRanking[i] = 100f;
				}
			}
		}
		return tempRanking;
	}
}
