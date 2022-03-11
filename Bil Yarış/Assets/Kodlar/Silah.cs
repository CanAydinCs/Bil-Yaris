using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah : MonoBehaviour {
    float damage = 1f;
    AudioSource audio;
    public float range = 10f;
    public Camera fpsCam;
    public ParticleSystem flash;
    public float fireRate = 15f;
    public AudioClip pistolSound;
    public MapBaslangıc mp;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update () {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && Time.timeScale == 1)
        {
            if (mp.boolSes)
            {
                audio.volume = mp.volumeSes;
                audio.PlayOneShot(pistolSound);
            }
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}

    void Shoot()
    {
        flash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("Cube"))
            {
                AtisDegdi hasar = hit.transform.GetComponent<AtisDegdi>();

                hasar.TakeDamage();
            }
        }
    }
}
