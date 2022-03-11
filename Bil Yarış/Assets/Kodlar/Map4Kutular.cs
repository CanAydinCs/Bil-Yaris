using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map4Kutular : MonoBehaviour {

    public Text soruTxt, puanTxt;
    public RandomAtama ra;
    public AudioClip dogruSes, yanlisSes;
    public UcakKontrol uk;
    public MapBaslangıc mp;

    AudioSource sesKaynagi;

	void Start () {
        sesKaynagi = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uk.Sifirla();
            if (ra.anlik_cevap == this.gameObject.name)
            {
                if (mp.boolSes)
                {
                    sesKaynagi.volume = mp.volumeSes;
                    sesKaynagi.PlayOneShot(dogruSes);
                }
                puanTxt.text = (int.Parse(puanTxt.text) + 100).ToString();
                soruTxt.text = "no";
            }
            else
            {
                if (mp.boolSes)
                {
                    sesKaynagi.volume = mp.volumeSes;
                    sesKaynagi.PlayOneShot(yanlisSes);
                }
                puanTxt.text = (int.Parse(puanTxt.text) - 100).ToString();
                soruTxt.text = "no";
            }
        }
    }
}
