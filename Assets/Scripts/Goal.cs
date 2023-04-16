using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float timer = 0;
    bool timerStop = false;
    public GameObject GoalCanvas;
    public GameObject GoalCanvasTimer;
    // Start is called before the first frame update
    void Start()
    {
        GoalCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStop)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer.ToString("0.00") + "s");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        timerStop = true;
        GoalCanvas.SetActive(true);
        GoalCanvasTimer.GetComponent<TextMeshProUGUI>().text = "Time: " + timer.ToString("0.00") + "s";
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
