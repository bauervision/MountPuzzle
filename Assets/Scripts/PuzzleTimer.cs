using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTimer : MonoBehaviour
{
    public static PuzzleTimer instance;
    public Text timerText;
    private float startTime;
    public bool finished = false;
    private int timeMinutes;
    private int timeSeconds;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public static void StartTimer()
    {
        instance.finished = false;
        instance.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (finished)
        {
            InteractionManager.finalMinutes = timeMinutes;
            InteractionManager.finalSeconds = timeSeconds;
            return;
        }

        float t = Time.time - startTime;
        timeMinutes = ((int)t / 60);
        timeSeconds = (int)(t % 60);

        timerText.text = timeMinutes.ToString() + ":" + timeSeconds.ToString("f0");
    }

}
