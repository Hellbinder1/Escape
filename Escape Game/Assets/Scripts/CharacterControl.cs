using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed = 10.0F;
	
    // Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

       // Debug.Log(straffe);
       // Debug.Log(translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;



        //var personPos = transform.position;
        //var keyPos = GameObject.Find("Key").transform.position;
        //var doorPos = GameObject.Find("Door").transform.position;

        //get the duistqnce between 2 points
       // var distancePersonKey = Mathf.Sqrt(Mathf.Pow(keyPos.x - personPos.x, 2) + Mathf.Pow(keyPos.y - personPos.y, 2) + Mathf.Pow(keyPos.z - personPos.z, 2));

       // var distancePersonDoor = Mathf.Sqrt(Mathf.Pow(doorPos.x - personPos.x, 2) + Mathf.Pow(doorPos.y - personPos.y, 2) + Mathf.Pow(doorPos.z - personPos.z, 2));

        //Debug.Log(distancePersonKey);
       // Debug.Log(distancePersonDoor);
    }

}
