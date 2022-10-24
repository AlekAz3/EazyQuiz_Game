using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseAnswerScript : MonoBehaviour
{
    [SerializeField] private Text buttonText;
    [SerializeField] private Text MainText;

    public void Button_Click()
    {
        MainText.text = buttonText.text;
        Debug.Log($"{buttonText.text} pressed");
    }

}
