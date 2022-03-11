using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketliKup : MonoBehaviour {

    public Transform[] konumlar;
    public float hiz;

    int hedefKonumSayisi = -1;
    Vector3 hedefKonum;
    bool hedefeUlasildi = true;

	void Update () {
        if (hedefeUlasildi)
        {
            hedefKonumSayisi++;
            if(hedefKonumSayisi == konumlar.Length)
            {
                hedefKonumSayisi = 0;
            }
            hedefKonum = konumlar[hedefKonumSayisi].position;
            hedefeUlasildi = false;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, hedefKonum, hiz * Time.deltaTime);

            hedefeUlasildi = Mathf.Abs(transform.position.x - hedefKonum.x) < 5 && Mathf.Abs(transform.position.z - hedefKonum.z) < 5;
        }
	}
}
