using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MapBaslangıc : MonoBehaviour {

    public bool boolSes;
    public float volumeSes;

    public AudioClip menuSes;
    AudioSource seskaynagi;

    public int mapNumber;
    public float hassasiyet_deger;
    string yol;
    public AudioSource music;
    public GameObject panelMenu, skorTablosu;
    public Text timer, anlikPuan, oyunBitti;
    public Button devamEt;
    public float kalanSure;
    List<string> isimler = new List<string>();
    List<int> puanlar = new List<int>();
    public Text[] isimlerText, skorlarText;
    bool gameOver = false;

    void Start () {
        yol = Application.dataPath + "\\Ayarlar";
        StreamReader oku = new StreamReader(yol + "\\genel.txt");
        boolSes = oku.ReadLine() == "t";
        volumeSes = float.Parse(oku.ReadLine());
        music.mute = (oku.ReadLine() == "f");
        music.volume = float.Parse(oku.ReadLine());
        hassasiyet_deger = float.Parse(oku.ReadLine());
        oku.Close();

        timer.text = kalanSure.ToString();

        ListeGuncelle();
        seskaynagi = GetComponent<AudioSource>();
        seskaynagi.volume = volumeSes;
        PlayerPrefs.SetString("UcaktaSes", boolSes ? "t" : "f");
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver && !skorTablosu.activeSelf)
        {
            panelMenu.SetActive(!panelMenu.activeSelf);
        }
        if (panelMenu.activeSelf || skorTablosu.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        kalanSure -= Time.deltaTime;
        timer.text = kalanSure > 0 ? kalanSure.ToString() : "0";

        if(kalanSure <= 0 && devamEt.enabled)
        {
            oyunBitti.text = "Oyun Bitti";
            devamEt.enabled = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            panelMenu.SetActive(true);
            gameOver = true;
            if(int.Parse(anlikPuan.text) > puanlar[puanlar.Count - 1])
            {
                int buyukOlduguDeger = puanlar.Count;
                foreach (int  item in puanlar)
                {
                    if (item > int.Parse(anlikPuan.text))
                        continue;
                    buyukOlduguDeger--;
                }
                List<string> kucukisimler = new List<string>();
                List<int> kucukPuanlar = new List<int>();
                for (int i = 8; i >= buyukOlduguDeger; i--)
                {
                    kucukisimler.Add(isimler[i]);
                    kucukPuanlar.Add(puanlar[i]);
                }
                isimler[buyukOlduguDeger] = "OYUNCU";
                puanlar[buyukOlduguDeger] = int.Parse(anlikPuan.text);
                for (int i = buyukOlduguDeger + 1, j = kucukisimler.Count - 1; i < puanlar.Count; i++, j--)
                {
                    isimler[i] = kucukisimler[j];
                    puanlar[i] = kucukPuanlar[j];
                }
                StreamWriter yazSkor = new StreamWriter(yol + "\\map" + mapNumber + "eniyi.txt");
                for (int i = 0; i < puanlar.Count; i++)
                {
                    yazSkor.WriteLine(isimler[i] + "-" + puanlar[i]);
                }
                yazSkor.Close();

                ListeGuncelle();
            }
        }
	}

    public void ButonDevam()
    {
        ButonTiklandi();
        panelMenu.SetActive(false);
    }

    public void SkorTablosu()
    {
        ButonTiklandi();
        panelMenu.SetActive(false);
        skorTablosu.SetActive(true);
    }

    public void Skor_Menu()
    {
        ButonTiklandi();
        if (gameOver)
        {
            oyunBitti.text = "Oyun Bitti";
        }
        else
        {
            oyunBitti.text = "Oyun Durduruldu";
        }
        panelMenu.SetActive(true);
        skorTablosu.SetActive(false);
    }

    public void Yukle(int deger)
    {
        ButonTiklandi();
        SceneManager.LoadScene(deger);
    }

    void ListeGuncelle()
    {
        puanlar.Clear();
        isimler.Clear();
        StreamReader okuSkor = new StreamReader(yol + "\\map" + mapNumber + "eniyi.txt");
        string satir = okuSkor.ReadLine();
        while (satir != null)
        {
            puanlar.Add(int.Parse(satir.Split('-')[1]));
            isimler.Add(satir.Split('-')[0]);
            satir = okuSkor.ReadLine();
        }
        okuSkor.Close();

        for (int i = 0; i < isimlerText.Length; i++)
        {
            isimlerText[i].text = isimler[i];
            skorlarText[i].text = puanlar[i].ToString();
        }
    }

    void ButonTiklandi()
    {
        if (boolSes)
        {
            seskaynagi.PlayOneShot(menuSes);
        }
    }
}
