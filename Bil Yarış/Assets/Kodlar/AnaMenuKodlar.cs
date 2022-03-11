using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuKodlar : MonoBehaviour {
    public GameObject anaSayfa, ayarlarAna, levelSec, credit, how2play;
    public AyarlarKurulum ay;

    private void Start()
    {
        ay = GetComponent<AyarlarKurulum>();
    }

    public void Basla()
    {
        anaSayfa.SetActive(false);
        levelSec.SetActive(true);
        ay.ButonTiklandi();
    }

    public void Ayarlar()
    {
        anaSayfa.SetActive(false);
        ayarlarAna.SetActive(true);
        ay.ButonTiklandi();
    }

    public void AnaSayfa()
    {
        anaSayfa.SetActive(true);
        ayarlarAna.SetActive(false);
        levelSec.SetActive(false);
        credit.SetActive(false);
        how2play.SetActive(false);
        ay.ButonTiklandi();
    }

    public void LevelSec(int index)
    {
        SceneManager.LoadScene(index);
        ay.ButonTiklandi();
    }

    public void Kapat()
    {
        ay.ButonTiklandi();
        Application.Quit();
    }

    public void Credit()
    {
        credit.SetActive(true);
        anaSayfa.SetActive(false);
        ay.ButonTiklandi();
    }

    public void How2Play()
    {
        how2play.SetActive(true);
        anaSayfa.SetActive(false);
        ay.ButonTiklandi();
    }
}
