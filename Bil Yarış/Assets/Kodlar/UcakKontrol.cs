using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcakKontrol : MonoBehaviour {

    Vector3 baslangic;
    Quaternion start;

	void Start () {
        baslangic = transform.position;
        start = transform.rotation;
	}
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Sifirla();
        }
	}

    public void Sifirla()
    {
        transform.position = baslangic;
        transform.rotation = start;
    }
}
