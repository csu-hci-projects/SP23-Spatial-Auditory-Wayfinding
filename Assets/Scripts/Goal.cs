using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float timer = 0;
    bool timerStop = false;
    public GameObject GoalCanvas;
    public GameObject GoalCanvasTimer;
    private List<string> triggers = new List<string>();
    [Header("Participant Data")]
    public int Participant;
    public enum Group
    {
        AControl,
        BSynthetic,
        CRealistic
    };
    public Group group;
    // Start is called before the first frame update
    void Start()
    {
        GoalCanvas.SetActive(false);
        //WriteString();
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
        if (other.name == "HeadCollider")
        {
            timerStop = true;
            GoalCanvas.SetActive(true);
            GoalCanvasTimer.GetComponent<TextMeshProUGUI>().text = "Time: " + timer.ToString("0.00") + "s";
            addToTriggersList(this.name);
            WriteString();
        }
            
    }
    public void addToTriggersList(string t)
    {
        Debug.Log(t);
        triggers.Add(t);
    }
    private void WriteString()
    {
        //triggers.Add("test trigger 1");
        //triggers.Add("test trigger 2");
        string path = "Assets/Resources/P" + Participant.ToString("D2") + "Gr" + group.ToString().Substring(0, 1) + ".txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Participant: "+Participant.ToString("D2"));
        writer.WriteLine("Group: "+group.ToString().Substring(0, 1));
        writer.WriteLine("Time: " + timer.ToString("0.00") + "s");
        writer.WriteLine();
        int i = 0;
        foreach (string trigger in triggers)
        {
            writer.WriteLine(++i + ") " + trigger);
        }
        writer.Close();
        //Re-import the file to update the reference in the editor
        /*AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("test");
        //Print the text from the file
        Debug.Log(asset.text);*/
    }
}
