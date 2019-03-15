using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject personModel;
    GameObject mainPlayer;
    GameObject cam;

    // Use this for initialization
    void Start()
    {
        personModel = GameObject.Find("PersonWIP");
        mainPlayer = GameObject.Find("Main Player");
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

        var moveDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        moveDirection = Vector2.Scale(moveDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, moveDirection.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, moveDirection.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -48f, 30f);

        transform.localRotation = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0);
        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        //var yValue = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //transform.localRotation = new Quaternion(transform.localRotation.x, yValue.y, transform.localRotation.z, transform.localRotation.w);

        personModel.transform.localRotation = transform.localRotation; // Quaternion.AngleAxis(mouseLook.x, mainPlayer.transform.up);

        //mainPlayer.transform.rotation = (mainPlayer.transform.localRotation.x, transform.localRotation.y, mainPlayer.transform.localRotation.z);
        var camEuler = transform.localRotation.eulerAngles;
        var mainEuler = mainPlayer.transform.localRotation.eulerAngles;

        mainPlayer.transform.rotation = Quaternion.Euler(mainEuler.x, camEuler.y, mainEuler.z);
    }
}
