using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtisDegdi : MonoBehaviour {
    public RandomAtama rA;
    public MapBaslangıc mp;

    public int mapNumber;
    public Text Skor;
    public AudioClip hataSesiMp3, dogruSes;
    AudioSource hataSesi;

    private void Start()
    {
        hataSesi = GetComponent<AudioSource>();
    }

    public void TakeDamage()
    {
        hataSesi.volume = mp.volumeSes;
        if (rA.anlik_cevap == gameObject.name)
        {
            switch (mapNumber)
            {
                case 2:
                    Skor.text = (int.Parse(Skor.text) + 100).ToString();
                    break;
                default:
                    break;
            }
            if (mp.boolSes)
            {
                hataSesi.PlayOneShot(dogruSes);
            }
        }
        else
        {
            switch (mapNumber)
            {
                case 2:
                    Skor.text = (int.Parse(Skor.text) - 100).ToString();
                    break;
                default:
                    break;
            }
            if (mp.boolSes)
            {
                hataSesi.PlayOneShot(hataSesiMp3);
            }
        }
        rA.Olusturuluyor();
    }
}
