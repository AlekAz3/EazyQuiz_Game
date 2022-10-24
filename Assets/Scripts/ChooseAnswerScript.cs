using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseAnswerScript : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private Text MainText;

	[SerializeField] private GameObject Obj;
	private GameManager game;
	
	private void Awake() {
		game = Obj.GetComponent<GameManager>();
	}
	public void Button_Click()
	{
		game.CheckAnswer(Convert.ToInt32(button.name));
	}

}
