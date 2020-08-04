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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (finished) return;

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds;
    }

}
