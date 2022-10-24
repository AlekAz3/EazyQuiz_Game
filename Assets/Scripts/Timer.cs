using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Slider bar;
    private float time;

    private void Awake() {
        bar = GetComponent<Slider>();    
    }


    private void Start() {
        StartTimer(5);
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
        Debug.Log("Time Out");
    }
}
