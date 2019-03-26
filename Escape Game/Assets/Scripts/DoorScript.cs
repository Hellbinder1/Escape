using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{

    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
        }

       



        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }

    void OnGUI()
    {
        var personPos = transform.position;
        var keyPos = GameObject.Find("Key").transform.position;
        var doorPos = GameObject.Find("Door").transform.position;
        var distanceDoorLimit = 1;

        //get the distance between 2 points
        var distancePersonKey = Mathf.Sqrt(Mathf.Pow(keyPos.x - personPos.x, 2) + Mathf.Pow(keyPos.y - personPos.y, 2) + Mathf.Pow(keyPos.z - personPos.z, 2));

        float distancePersonDoor = Mathf.Sqrt(Mathf.Pow(doorPos.x - personPos.x, 2) + Mathf.Pow(doorPos.y - personPos.y, 2) + Mathf.Pow(doorPos.z - personPos.z, 2));

        if (inTrigger)
        {
            if (distancePersonDoor <= distanceDoorLimit)
            {


                if (open)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Press E to close");
                }
                else
                {
                    if (doorKey)
                    {
                        GUI.Box(new Rect(0, 0, 200, 25), "Press E to open");
                    }
                    else
                    {
                        GUI.Box(new Rect(0, 0, 200, 25), "Need a key!");
                    }
                }
            }
        }
    }
}