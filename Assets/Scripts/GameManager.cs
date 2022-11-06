using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;

public class GameManager : MonoBehaviour
{
	private string adress = "192.168.1.127:7127";
	
	[SerializeField] private GameObject GameOver;
	[SerializeField] private GameObject LoadScreen;
	[SerializeField] private Slider Timer;
	[SerializeField] private List<Button> Buttons;
	[SerializeField] private TextMeshProUGUI text_question;
    private questions question;
	private List<answer> answers;
	
	private void Start() {
		Loading();
	}
	
	public void StartGame()
	{
		Timer.GetComponent<Timer>().StartTimer(15);
        answers.Sort((a, b) => 1 - 2 * Random.Range(0, answers.Count));
        for (int i = 0; i < Buttons.Count; i++)
			Buttons[i].GetComponent<ChooseAnswerScript>().InitAns(answers[i]);

		text_question.text = question.q_text.ToString();

    }
	
	public void Loading()
	{
		GameOver.SetActive(false);
		LoadScreen.SetActive(true);
		StartCoroutine(Load(Random.Range(1, 14)));
	}

	private IEnumerator Load(int id)
	{
        yield return StartCoroutine(GetQuestion(id));
        yield return StartCoroutine(GetAnswers(id));
		LoadScreen.SetActive(false);
		StartGame();
	}

    private IEnumerator GetQuestion(int id)
	{
		string url = $"http://{adress}/api/Values/Get_Question?id_question={id}";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
		{
			yield return request.SendWebRequest();
			if (request.result == UnityWebRequest.Result.ProtocolError)
				Debug.Log(request.error);
			else
				question = JsonConvert.DeserializeObject<questions>(request.downloadHandler.text);
		}

	}

    private IEnumerator GetAnswers(int id)
	{
		string url = $"http://{adress}/api/Values/Get_Answer?id_question={id}";

		using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError)
                Debug.Log(request.error);
            else
                answers = JsonConvert.DeserializeObject<List<answer>>(request.downloadHandler.text);
        }
    }
	
	
	
	public void CheckAnswer(bool ans)
	{
		Timer.GetComponent<Timer>().StopAllCoroutines();
		if (ans)
			GameOverScreenOn("Правильно");
		else
			GameOverScreenOn("Неправильно");
	}
	
	public void GameOverScreenOn(string message)
	{
		GameOver.GetComponentInChildren<Text>().text = message;
		GameOver.SetActive(true);
	}



}
