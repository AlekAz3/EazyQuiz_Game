using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseAnswerScript : MonoBehaviour
{
	private answer answer;
	[SerializeField] private GameObject Obj;
	private GameManager game;
	
	private void Awake() {
		game = Obj.GetComponent<GameManager>();
	}


	public void InitAns(answer answer1)
	{
		this.answer = answer1;
		this.GetComponentInChildren<Text>().text = this.answer.a_text;
		
	}


	public void Button_Click()
	{
		game.CheckAnswer(answer);
	}

}
