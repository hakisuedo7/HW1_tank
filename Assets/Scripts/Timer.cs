using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer_f = 0f;
    int timer_i = 0;
    int minute = 0;
    int second = 0;
    // Update is called once per frame
    void Update()
    {
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        turn_time();
        //丁笆
        if (minute < 10)
        {

            if (second < 10)
            {
                GetComponent<Text>().text = "计:0" + minute + ":0" + second;
            }
            else
            {
                GetComponent<Text>().text = "计:0" + minute + ":" + second;
            }
        }
        else
        {
            if (second < 10)
            {
                GetComponent<Text>().text = "计:" + minute + ":0" + second;
            }
            else
            {
                GetComponent<Text>().text = "计:" + minute + ":" + second;
            }
        }
    }
    void turn_time()
    {
        minute = timer_i / 60;
        second = timer_i % 60;
    }
}
