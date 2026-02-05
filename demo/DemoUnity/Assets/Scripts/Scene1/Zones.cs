using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Zones : MonoBehaviour
{
    public GameObject Fusee;

    public ParticleSystem Explosion;

    public Slider RightSlider;
    public Slider LeftSlider;
    public Slider MainSlider;

    public ParticleSystem Feu1;
    public ParticleSystem Feu2;
    public ParticleSystem Feu3;

    public bool PlayerIsDead = false;

    [Header("Son Explosion")]
    public AudioSource explosionSound;

    [Header("Ambience Terre")]
    public AudioSource ambienceTerre; // ambiance de la Terre

    public void TriggerExplosion()
    {
        Fusee.GetComponent<Renderer>().enabled = false;
        Explosion.Play();

        if (explosionSound != null)
            explosionSound.Play();

        PlayerIsDead = true;

        MainSlider.value = 0;
        RightSlider.value = 0;
        LeftSlider.value = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        // Entrer dans la zone Earth → jouer l’ambience Terre
        if (other.CompareTag("Player") && gameObject.CompareTag("Earth"))
        {
            if (ambienceTerre != null && !ambienceTerre.isPlaying)
                ambienceTerre.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Sortir de la zone de jeu → explosion
        if (other.CompareTag("Player") && gameObject.CompareTag("GameZone"))
        {
            TriggerExplosion();
        }

        // Sortir de la zone Earth → arrêter l’ambience Terre
        if (other.CompareTag("Player") && gameObject.CompareTag("Earth"))
        {
            if (ambienceTerre != null && ambienceTerre.isPlaying)
                ambienceTerre.Stop();
        }
    }

    void Start()
    {
        Explosion.Stop();

        if (ambienceTerre != null)
            ambienceTerre.Stop();
    }
}
