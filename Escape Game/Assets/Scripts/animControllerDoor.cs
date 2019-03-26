using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControllerDoor : MonoBehaviour {

    public Animator anim;
    public static bool play = false;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (play == true)
        {
                anim.Play("openDoor");
        }
        
	}
}
