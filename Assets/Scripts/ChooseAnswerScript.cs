using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseAnswerScript : MonoBehaviour
{
	public bool Is_Correct { get; set; }
	[SerializeField] private GameObject Obj;
	private GameManager game;
	
	private void Awake() {
		game = Obj.GetComponent<GameManager>();
	}


	public void InitAns(answer answer)
	{
		this.GetComponentInChildren<Text>().text = answer.a_text;
		this.Is_Correct = answer.is_correct;
	}


	public void Button_Click()
	{
		game.CheckAnswer(this.Is_Correct);
	}

}
