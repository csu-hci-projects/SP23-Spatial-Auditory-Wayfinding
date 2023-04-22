using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMovement : MonoBehaviour
{
    //https://youtu.be/zoql4VZ2i80

    public SteamVR_Action_Vector2 moveValue;
    public float maxSpeed;
    public float sensitivity;
    public float collisionDistance;
    public Rigidbody headRigidbody;
    private float speed = 0;

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //if(headRigidbody.SweepTest(Player.instance.hmdTransform.TransformDirection(Vector3.forward), out hit, collisionDistance)) {}
        //else
        //{
            //Debug.Log(moveValue.axis.y);
            if (moveValue.axis.y > 0)
            {
                Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(0, 0, moveValue.axis.y));
                speed = moveValue.axis.y * sensitivity;
                speed = Mathf.Clamp(speed, 0, maxSpeed);
                transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
            }
            else if (moveValue.axis.y < 0)
            {
                Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(0, 0, moveValue.axis.y));
                speed = moveValue.axis.y * sensitivity;
                speed = Mathf.Clamp(speed, -maxSpeed, 0);
                transform.position -= speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
            }
        //}
        /*if (headRigidbody.SweepTest(Player.instance.hmdTransform.TransformDirection(Vector3.forward), out hit, collisionDistance)) { }
        else
        {

        }*/
    }

    public void pressDown()
    {
        Debug.Log("menu button pressed down");
    }
    public void pressUp()
    {
        Debug.Log("menu button pressed up");
    }
}
