using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKeyScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        var key = GameObject.Find("Key");


        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc == key)
                {
                    Destroy(this.gameObject);
                }
            }
        }
	}
}
