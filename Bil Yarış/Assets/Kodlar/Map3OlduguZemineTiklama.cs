using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map3OlduguZemineTiklama : MonoBehaviour {

    public RandomAtama rA;
    public Text soruText, puanText;
    public AudioClip hataSesi, dogruSes;
    public MapBaslangıc mp;
    public GameObject[] kupler;

    GameObject guncelKup;
    AudioSource sesKaynagi;
    Vector3 baslangıcKonumu;

    private void Start()
    {
        baslangıcKonumu = transform.position;
        sesKaynagi = GetComponent<AudioSource>();
    }

    void Update () {
        foreach (GameObject item in kupler)
        {
            if(Mathf.Abs(transform.position.x - item.transform.position.x) < 5 && Mathf.Abs(transform.position.z - item.transform.position.z) < 5)
            {
                guncelKup = item;
                break;
            }
        }

        if(transform.position.y < -6)
        {
            Hata();
            transform.position = baslangıcKonumu;
        }

		if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if(guncelKup.name == rA.anlik_cevap)
            {
                puanText.text = (int.Parse(puanText.text) + 100).ToString();
                if (mp.boolSes)
                {
                    sesKaynagi.volume = mp.volumeSes;
                    sesKaynagi.PlayOneShot(dogruSes);
                }
            }
            else
            {
                Hata();
            }
            soruText.text = "no";
        }
	}

    void Hata()
    {
        puanText.text = (int.Parse(puanText.text) - 100).ToString();
        if (mp.boolSes)
        {
            sesKaynagi.volume = mp.volumeSes;
            sesKaynagi.PlayOneShot(hataSesi);
        }
    }
}
