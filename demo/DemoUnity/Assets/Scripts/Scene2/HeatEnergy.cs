using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatEnergy : MonoBehaviour
{
    Coroutine HeatRoutine;
    Coroutine ColdRoutine;
    public static HeatEnergy Instance;

    [Header("UI")]

    public Slider HeatSlider;
    public Slider EnergySlider;
    public Image LightOpacity;

    [Header("Scripts")]
    public FirstPersRocket FirstPersRocket;
    public Controllers Controllers;

    [Header("Values")]

    public float CurrentEngineHeat = 0;
    public float IncomingEngineHeat = 0;
    public float CurrentEnergy = 100;
    public bool LightsOn = true;
    public bool Drifting = false;
    public bool ShieldActive = false;
    public bool RadarActive = false;

    [Header("Objects")]

    public GameObject Shield;
    public GameObject Radar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // EMPÊCHE LA JAUGE D'ÉNERGIE / CHALEUR DE DÉPASSER LES LIMITES
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0f, 100f);
        CurrentEngineHeat = Mathf.Clamp(CurrentEngineHeat, 0f, 100f);

        // RÉACTIVE LE SYSTÈME DE CHAUFFAGE DU MOTEUR !! NE PAS RETIER !! 
        if (IncomingEngineHeat > 0 && HeatRoutine == null)
    {
        HeatRoutine = StartCoroutine(HeatUpdate());
    }

        // ACTIVE LE SYSTÈME DE REFROIDISSEMENT DU MOTEUR !! NE PAS RETIRER !!
    if (IncomingEngineHeat == 0 && ColdRoutine == null)
    {
        ColdRoutine = StartCoroutine(ColdUpdate());
    }

        

        //CHALEUR ENTRANTE
        IncomingEngineHeat = (FirstPersRocket.TotalPower*100)/300; // Valeur retournée sur 100

        // ACTUALISATION DE L'ÉNERGIE UI
        EnergySlider.value = CurrentEnergy;


        // BOUTON REFROIDISSEMENT 
        if (Controllers.TurningButton3 == true)
        {
            if (CurrentEnergy > 0)
            {
                CurrentEngineHeat -= 11f * Time.deltaTime;
                CurrentEnergy -= 11f * Time.deltaTime;
            }
            
        }

        // BOUTON RECHARGEMENT D'ÉNERGIE 
        if (Controllers.TurningButton2 == true)
        {
            CurrentEngineHeat += 5f * Time.deltaTime;
            CurrentEnergy += 25f * Time.deltaTime;
        }

        // AFFICHE LA CHALEUR SUR LE UI 
            HeatSlider.value = CurrentEngineHeat;


        // ACTIVE / DÉSACTIVE LES LUMIÈRES AU CLIC DU BOUTON
        if (Controllers.Button2 == true && LightsOn == true)
        {
            LightsOn = false;
        } else if (Controllers.Button2 == true && LightsOn == false)
        {
            LightsOn = true;
        }

        // ACTIVE LE BOUCLIER LORSQUE LE BOUTON EST MAINTENU
        if (Controllers.Button1 == true)
        {
            ShieldActive = true;
        } else
        {
            ShieldActive = false;
        }

        // ACTIVE LE RADAR OU LE DÉSACTIVE LORS DU CLIC
        if (Controllers.Button3 == true && !RadarActive)
        {
            RadarActive = true;
        } else if (Controllers.Button3 == true && RadarActive)
        {
            RadarActive = false;
        }


        // AFFICHE LA BONNE LUMINOSITÉ DÉPENDAMENT SI LES LUMIÈRES SONT ACTIVES OU PAS
        if (LightsOn)
        {
            Color c = LightOpacity.color;
            c.a = Mathf.Clamp01(0f / 255f);
            LightOpacity.color = c;
            CurrentEnergy -= 1f * Time.deltaTime;
        } else
        {
            Color c = LightOpacity.color;
            c.a = Mathf.Clamp01(254f / 255f);
            LightOpacity.color = c;
        }

        // SYSTÈME PERMETTANT L'ACTIVATION DU BOUCLIER

        if (ShieldActive)
        {
            Shield.SetActive(true);
            CurrentEnergy -= 15f * Time.deltaTime;
            // Rajouter ici la méthode protégeant contre les impacts
        } else
        {
            Shield.SetActive(false);
        }

        // SYTÈME QUI PERMET D'AFFICHER OU CACHER LE RADAR
        if (RadarActive)
        {
            Radar.SetActive(true);
        } else 
        {
            Radar.SetActive(false);
        }


        // COUPURE DE COURANT

        if (CurrentEnergy < 0)
        {
            LightsOn = false;
            ShieldActive = false;
        }
        

        // DRIFT

        Drifting = Controllers.TurningButton1;

        if (Drifting)
        {
            CurrentEngineHeat += 2f * Time.deltaTime;
        }




    }

        IEnumerator HeatUpdate()
    {
        while (IncomingEngineHeat > 0)
        {
            // CHALEUR DU MOTEUR
            yield return new WaitForSeconds(1f);

            // NOUVELLE CHALEUR AJOUTÉE AU MOTEUR
            CurrentEngineHeat = CurrentEngineHeat + (IncomingEngineHeat/30);

            CurrentEngineHeat = Mathf.Clamp(CurrentEngineHeat, 0f, 100f);

            Debug.Log(CurrentEngineHeat);
            
            
        }

        HeatRoutine = null;
    }

        IEnumerator ColdUpdate()
    {
        while (IncomingEngineHeat == 0)
        {
            // REFROIDISSEMENT DU MOTEUR
            yield return new WaitForSeconds(1.5f);

            CurrentEngineHeat = CurrentEngineHeat - 8;

            CurrentEngineHeat = Mathf.Clamp(CurrentEngineHeat, 0f, 100f);

            Debug.Log(CurrentEngineHeat);
            
        }

        ColdRoutine = null;
    }


}
