using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongTurn : MonoBehaviour
{
    public GameObject Goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name== "HeadCollider")
        {
            //Debug.Log(other.name);
            //Debug.Log(this.name);
            Goal.GetComponent<Goal>().addToTriggersList(this.name);
        }
    }
}
