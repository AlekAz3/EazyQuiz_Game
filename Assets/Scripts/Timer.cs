using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	private Slider bar;
	private float time;
	
	[SerializeField] private GameObject game;
	
	private void Awake() {
		bar = GetComponent<Slider>();
		
	}

	public void StartTimer(float CooldownTime)
	{
		Debug.Log("Start Timer");
		bar.maxValue = CooldownTime;
		time = CooldownTime;
		StartCoroutine(timer());
	}


	IEnumerator timer()
	{
		while (time>0)
		{
			time-=Time.deltaTime;
			bar.value = time;
			yield return null;
		}
		game.GetComponent<GameManager>().GameOverScreenOn("Время вышло");
		
	}
}
