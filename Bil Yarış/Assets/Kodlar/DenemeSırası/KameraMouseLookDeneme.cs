using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraMouseLookDeneme : MonoBehaviour {

    public float mouseHassaslıgı;
    public Transform playerBody;
    float xRotation = 0f;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	
	void Update ()
    {
        mouseHassaslıgı = 160;
        playerBody.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseHassaslıgı * Time.deltaTime);

        xRotation -= Input.GetAxis("Mouse Y") * mouseHassaslıgı * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
