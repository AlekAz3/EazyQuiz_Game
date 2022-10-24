using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	
	private int RightAnswer;
	
	[SerializeField] private GameObject GameOver;
	[SerializeField] private Slider Timer;
	
	
	
	private void Start() {
		StartGame();
	}
	
	public void StartGame()
	{
		GameOver.SetActive(false);
		RightAnswer = Random.Range(0, 4);
		Timer.GetComponent<Timer>().StartTimer(10);
	}
	
	
	public void CheckAnswer(int option)
	{
		Timer.GetComponent<Timer>().StopAllCoroutines();
		if (RightAnswer == option)
			GameOverScreenOn("Верно");
		else
			GameOverScreenOn("Не верно");
		
	}
	
	public void GameOverScreenOn(string message)
	{
		GameOver.GetComponentInChildren<Text>().text = message;
		GameOver.SetActive(true);
	}
	
}
