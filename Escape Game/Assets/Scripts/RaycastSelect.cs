using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelect : MonoBehaviour
{

    public float selectionDistance = 1f;
    public LayerMask layermask;
    public Animator anim;

    private GameObject currentTarget;

    GameObject door;
    GameObject key;
    bool gotKey = false;


    // Update is called once per frame

    void Start()
    {
        door = GameObject.Find("Door");
        key = GameObject.Find("Key");
        anim = GetComponent<Animator>();
       
    }



    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, selectionDistance, layermask))
        {

            if (currentTarget == null)
            {
                currentTarget = hit.transform.gameObject;
                OnRaycastEnter(currentTarget);
            }

            else if (currentTarget != hit.transform.gameObject)
            {
                OnRaycastLeave(currentTarget);
                currentTarget = hit.transform.gameObject;
                OnRaycastEnter(currentTarget);
            }

            else if (currentTarget == key)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gotKey = true;
                    Destroy(GameObject.Find("Key"));


                }
            }

            else if (currentTarget == door)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gotKey == true)
                    {
                        //door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 10000000);
                        animControllerDoor.play = true;
                    }                   
                }
                
            }




        }

        else if (currentTarget != null)
        {
            OnRaycastLeave(currentTarget);
            currentTarget = null;
        }

    }

    


    protected virtual void OnRaycastEnter(GameObject target)
    {
    }

    protected virtual void OnRaycastLeave(GameObject target)
    {
    }

    protected virtual void OnRaycast(GameObject target)
    {
    }
}