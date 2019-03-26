using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour
{

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
        var personPos = transform.position;
        var keyPos = GameObject.Find("Key").transform.position;
        var distancePersonKey = Mathf.Sqrt(Mathf.Pow(keyPos.x - personPos.x, 2) + Mathf.Pow(keyPos.y - personPos.y, 2) + Mathf.Pow(keyPos.z - personPos.z, 2));
        var distanceKeyLimit = 0.000001;


        if (inTrigger)
        {
            if (distancePersonKey <= distanceKeyLimit)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoorScript.doorKey = true;
                    Destroy(this.gameObject);

                }
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
        }
    }
}