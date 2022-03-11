using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAtama : MonoBehaviour {

    public Material[] materyaller;
    public Image[] resimler;
    public Text[] yazilar;
    public GameObject[] kupler;
    public GameObject panel;
    public Text soru;
    public string anlik_cevap;
    public List<string> sorular, cevaplar;
    int onceki_cevap, oncekiDogruKup, dogruKup, cevap;

	void Start () {
        Olusturuluyor();
        oncekiDogruKup = cevap = dogruKup = onceki_cevap = -1;
	}
	
	
	void Update () {
        if(soru.text == "no")
        {
            Olusturuluyor();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale == 1)
        {
            panel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            panel.SetActive(false);
        }
	}

    public void Olusturuluyor()
    {
        while (cevap == onceki_cevap)
        {
            cevap = Random.Range(0, sorular.Count);
        }

        soru.text = sorular[cevap];
        anlik_cevap = cevaplar[cevap];
        onceki_cevap = cevap;

        List<int> kullanilan_renkler = new List<int>();
        List<int> kullanilan_sayilar = new List<int>();
        int secilenRenk = 0;
        int randomCevap = 0;

        while (dogruKup == oncekiDogruKup)
        {
            dogruKup = Random.Range(0, 5);
        }

        for (int i = 0; i < 5; i++)
        {
            while (kullanilan_renkler.Contains(secilenRenk))
            {
                secilenRenk = Random.Range(0, 5);
            }

            while (kullanilan_sayilar.Contains(randomCevap) || randomCevap == cevap)
            {
                randomCevap = Random.Range(0, cevaplar.Count);
            }

            switch (secilenRenk)
            {
                case 0:
                    materyaller[i].color = Color.green;
                    resimler[i].color = Color.green;
                    break;
                case 1:
                    materyaller[i].color = Color.black;
                    resimler[i].color = Color.black;
                    break;
                case 2:
                    materyaller[i].color = Color.blue;
                    resimler[i].color = Color.blue;
                    break;
                case 3:
                    materyaller[i].color = Color.red;
                    resimler[i].color = Color.red;
                    break;
                case 4:
                    materyaller[i].color = Color.yellow;
                    resimler[i].color = Color.yellow;
                    break;
            }

            if(i == dogruKup)
            {
                kupler[i].name = cevaplar[cevap];
                yazilar[i].text = cevaplar[cevap];
                kullanilan_sayilar.Add(cevap);
            }
            else
            {
                kupler[i].name = cevaplar[randomCevap];
                yazilar[i].text = cevaplar[randomCevap];
                kullanilan_sayilar.Add(randomCevap);
            }
            
            kullanilan_renkler.Add(secilenRenk);
        }
        oncekiDogruKup = dogruKup;
    }
}
