using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] ParticleSystem embers;
    [SerializeField] ParticleSystem weapon;
    [SerializeField] ParticleSystem fireball;
    [SerializeField] Material weakMaterial;
    [SerializeField] Material strongMaterial;

    private bool down;
    private float start;
    private ParticleSystem.MainModule embersMain;
    private ParticleSystem.EmissionModule weaponEmission, embersEmission;

    void Start()
    {
        weapon.Stop();
        embersMain = embers.main;
        embersEmission = embers.emission;
        weaponEmission = weapon.emission;
        embersMain.startColor = new Color(0.8207547f, 0.474397f, 0.1509879f, 0.5f);
        embersEmission.rateOverTime = 2;
        down = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = Time.time;
            embersMain.startColor = new Color(0.8207547f, 0.474397f, 0.1509879f, 0.75f);
            embersEmission.rateOverTime = 8;
            weaponEmission.rateOverTime = 2;
            fireball.GetComponent<Renderer>().material = weakMaterial;
            down = true;
        }
        if (down && Time.time - start > 2.5)
        {
            fireball.GetComponent<Renderer>().material = strongMaterial;
            embersMain.startColor = new Color(0.3460751f, 0.3495806f, 0.7264151f, 0.75f);
            embersEmission.rateOverTime = 12;
            weaponEmission.rateOverTime = 3;
/*            weapon.forceOverLifetime.y = -14.7;
*/        }
        if(Input.GetMouseButtonUp(0))
        {
            weapon.Play();
            embersMain.startColor = new Color(0.8207547f, 0.474397f, 0.1509879f, 0.5f);
            embersEmission.rateOverTime = 2;
            down = false;
        }
    }
}
