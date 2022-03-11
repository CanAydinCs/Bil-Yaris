using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSistemi : MonoBehaviour {

    RaycastHit ry;
    public Text soru, puan;
    public RandomAtama rndmAtama;
    public GameObject karakter;
    public MapBaslangıc mp;
    Vector3 baslangic;

    public AudioClip hataSesi, dogruSes;
    AudioSource sesKaynak;

    private void Start()
    {
        baslangic = karakter.transform.position;
        sesKaynak = GetComponent<AudioSource>();
    }

    void Update () {
		if(Physics.Raycast(transform.position,transform.forward,out ry, 5))
        {
            if(ry.transform.tag == "Cube" && Input.GetMouseButtonDown(0) && Time.timeScale == 1)
            {
                if(rndmAtama.anlik_cevap == ry.transform.gameObject.name)
                {
                    puan.text = (int.Parse(puan.text) + 100).ToString();
                    soru.text = "no";
                    if (mp.boolSes)
                    {
                        sesKaynak.volume = mp.volumeSes;
                        sesKaynak.PlayOneShot(dogruSes);
                    }
                }
                else
                {
                    puan.text = (int.Parse(puan.text) - 100).ToString();
                    karakter.transform.position = baslangic;
                    if (mp.boolSes)
                    {
                        sesKaynak.volume = mp.volumeSes;
                        sesKaynak.PlayOneShot(hataSesi);
                    }
                }
            }
        }
	}
}
