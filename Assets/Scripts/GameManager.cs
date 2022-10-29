using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
	
	private int RightAnswer;
	
	[SerializeField] private GameObject GameOver;
	[SerializeField] private Slider Timer;
	[SerializeField] private List<Button> Buttons = new List<Button>(4);
	
	
	private void Start() {
		StartGame();
	}
	
	public void StartGame()
	{
		GameOver.SetActive(false);
		RightAnswer = Random.Range(0, 4);
		StartCoroutine(GetQuestion("http://localhost:7127/api/Values/Get_Question?id_question=4"));
		Timer.GetComponent<Timer>().StartTimer(10);
	}
	
	
	IEnumerator GetQuestion(string url)
	{
		UnityWebRequest uwr = UnityWebRequest.Get(url); 
		yield return uwr.SendWebRequest();

		if (uwr.isNetworkError)
			Debug.Log("Error While Sending: " + uwr.error);
		
		else
			Debug.Log("Received: " + uwr.downloadHandler.text);
	
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
