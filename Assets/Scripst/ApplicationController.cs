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

		for(int i=numberPositionRanking-1; i>=0; i--)
		{
			if(tempo < tempRanking[i])
			{
				positionScore = i;
			}
		}
		if(positionScore > -1)
		{
			for(int i = numberPositionRanking-1; i>=0; i--)
			{
				if(i != positionScore && i !=0)
				{
					PlayerPrefs.SetFloat("Position"+i, tempRanking[i-1]);
				}
				else if(i == positionScore)
				{
					PlayerPrefs.SetFloat("Position"+i, tempo);
				}
			}
		}
	}

	public static void ResetRanking(int mode)
	{
		if(mode == 1)
		{
			for(int i =0; i<numberPositionRanking; i++)
				PlayerPrefs.SetFloat("Position"+i, 100f);
		}
		else if(mode == 2)
		{
			PlayerPrefs.SetFloat("Position"+0, 32f);
			PlayerPrefs.SetFloat("Position"+1, 36.5f);
			PlayerPrefs.SetFloat("Position"+2, 42.8f);
			PlayerPrefs.SetFloat("Position"+3, 50.3f);
			PlayerPrefs.SetFloat("Position"+4, 55.1f);
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
			else{
				ResetRanking(2);
			}
		}
		return tempRanking;
	}
}
