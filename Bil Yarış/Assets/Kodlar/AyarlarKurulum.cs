using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AyarlarKurulum : MonoBehaviour {

    string genel_yol;

    public Text btnSes, btnMusic, SldYazi;
    public Slider sliderHassasiyet, sliderSes, SliderMusic;
    public AudioSource AnaMenuMusic;
    public int mapSayisi;
    public AudioClip menuSes;

    bool boolSes, boolMusic;
    float hassasiyet, ses, music;
    AudioSource sesKaynagi;

	void Start () {
        sesKaynagi = GetComponent<AudioSource>();

        string yol = Application.dataPath;
        genel_yol = yol + "\\Ayarlar\\genel.txt";
        if (!File.Exists(yol + "\\Ayarlar"))
        {
            Directory.CreateDirectory(yol + "\\Ayarlar");
            
        }
        if (!File.Exists(yol + "\\Ayarlar\\genel.txt"))
        {
            StreamWriter yaz = File.CreateText(yol + "\\Ayarlar\\genel.txt");
            yaz.WriteLine("t\n1\nt\n1\n100");
            yaz.Close();
            boolSes = true;
            ses = 1;
            boolMusic = true;
            music = 1;
            hassasiyet = 100;
            for (int i = 1; i < mapSayisi + 1; i++)
            {
                StreamWriter yazıcı = new StreamWriter(yol + "\\Ayarlar\\map" + i + "eniyi.txt");
                for (int j = 10; j > 0; j--)
                {
                    yazıcı.WriteLine("BOT-" + (j * 100));
                }
                yazıcı.Close();
            }
        }
        else
        {
            StreamReader oku = new StreamReader(genel_yol);
            boolSes = oku.ReadLine() == "t";
            ses = float.Parse(oku.ReadLine());
            boolMusic = oku.ReadLine() == "t";
            music = float.Parse(oku.ReadLine());
            hassasiyet = float.Parse(oku.ReadLine());
            oku.Close();
        }

        btnSes.text = boolSes ? "Sesler Açık" : "Sesler Kapalı";
        btnMusic.text = boolMusic ? "Müzik Açık" : "Müzik Kapalı";
        AnaMenuMusic.mute = !boolMusic;
        
        sliderHassasiyet.value = hassasiyet;
        sliderSes.value = ses;
        SliderMusic.value = music;
        SldYazi.text = hassasiyet.ToString();

        sesKaynagi.volume = ses;
	}

    public void SesDegistirBtn()
    {
        boolSes = !boolSes;
        btnSes.text = boolSes ? "Sesler Açık" : "Sesler Kapalı";
        ButonTiklandi();
    }

    public void SesDegistirSld()
    {
        ses = sliderSes.value;
        sesKaynagi.volume = ses;
    }
    
    public void MusicDegistirBtn()
    {
        boolMusic = !boolMusic;
        btnMusic.text = boolMusic ? "Müzik Açık" : "Müzik Kapalı";
        AnaMenuMusic.mute = !boolMusic;
        ButonTiklandi();
    }

    public void MusicDegistirSld()
    {
        music = SliderMusic.value;
        AnaMenuMusic.volume = music;
    }

    public void Hassaslik()
    {
        hassasiyet = sliderHassasiyet.value;
        SldYazi.text = hassasiyet.ToString();
    }

    public void Sifirla()
    {
        if (!boolSes)
        {
            SesDegistirBtn();
        }
        if (!boolMusic)
        {
            MusicDegistirBtn();
        }
        ses = 1;
        music = 1;
        hassasiyet = 100;
        sliderSes.value = 1;
        SliderMusic.value = 1;
        sliderHassasiyet.value = 100;
        ButonTiklandi();
    }

    public void Kayit()
    {
        StreamWriter yaz = new StreamWriter(genel_yol);
        yaz.WriteLine(boolSes ? "t" : "f");
        yaz.WriteLine(ses);
        yaz.WriteLine(boolMusic ? "t" : "f");
        yaz.WriteLine(music);
        yaz.WriteLine(hassasiyet);
        yaz.Close();   
    }

    public void ButonTiklandi()
    {
        if (boolSes)
        {
            sesKaynagi.PlayOneShot(menuSes);
        }
    }
}
