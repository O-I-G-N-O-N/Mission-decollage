using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatEnergy : MonoBehaviour
{


    Coroutine HeatRoutine;
    Coroutine ColdRoutine;


    [Header("Buttons")]

    public bool Button1 = false;
    public bool Button2 = false;
    public bool Button3 = false;
    public bool Button4 = false;
    public bool Button5 = false;
    public bool Button6 = false;
    public bool TurningButton1 = false;

    [Header("UI")]

    public Slider HeatSlider;
    public Slider EnergySlider;
    public Image LightOpacity;

    [Header("Scripts")]
    public FirstPersRocket FirstPersRocket;

    [Header("Values")]

    public float CurrentEngineHeat = 0;
    public float IncomingEngineHeat = 0;
    public float CurrentEnergy = 100;
    public bool LightsOn = true;
    public bool Drifting = false;

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

        // ACTIVATION DES BOUTONS

        // BOUTON 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        Button1 = true;
        Debug.Log(FirstPersRocket.TotalPower);
    } else
        {
            Button1 = false;
        }

        // BOUTON 2 -- REFROIDISSEMENT MOTEUR
        if (Input.GetKey(KeyCode.Alpha2))
    {
        Button2 = true;
        Debug.Log(Button2);
    } else
        {
            Button2 = false;
        }


        // BOUTON 3 -- RECHARGE ÉNERGIE
        if (Input.GetKey(KeyCode.Alpha3))
    {
        Button3 = true;
        Debug.Log(Button3);
    } else
        {
            Button3 = false;
        }


        // BOUTON 4 -- LUMIÈRES
        if (Input.GetKeyDown(KeyCode.Alpha4))
    {
        Button4 = true;
        Debug.Log(Button4);
    } else
        {
            Button4 = false;
        }


        // BOUTON 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
    {
        Button5 = true;
        Debug.Log(Button5);
    } else
        {
            Button5 = false;
        }


        // BOUTON 6
        if (Input.GetKeyDown(KeyCode.Alpha6))
    {
        Button6 = true;
        Debug.Log(Button6);
    } else
        {
            Button6 = false;
        }


        // TURNING BUTTON 1
        if (Input.GetKey(KeyCode.Alpha7))
    {
        TurningButton1 = true;
        Debug.Log(TurningButton1);
    } else
        {
            TurningButton1 = false;
        }

        //CHALEUR ENTRANTE
        IncomingEngineHeat = (FirstPersRocket.TotalPower*100)/300; // Valeur retournée sur 100

        // ACTUALISATION DE L'ÉNERGIE UI
        EnergySlider.value = CurrentEnergy;


        // BOUTON REFROIDISSEMENT 
        if (Button2 == true)
        {
            if (CurrentEnergy > 0)
            {
                CurrentEngineHeat -= 11f * Time.deltaTime;
                CurrentEnergy -= 11f * Time.deltaTime;
            }
            
        }

        // BOUTON RECHARGEMENT D'ÉNERGIE 
        if (Button3 == true)
        {
            CurrentEngineHeat += 5f * Time.deltaTime;
            CurrentEnergy += 25f * Time.deltaTime;
        }

        // AFFICHE LA CHALEUR SUR LE UI 
            HeatSlider.value = CurrentEngineHeat;


        // ACTIVE / DÉSACTIVE LES LUMIÈRES AU CLIC DU BOUTON
        if (Button4 == true && LightsOn == true)
        {
            LightsOn = false;
        } else if (Button4 == true && LightsOn == false)
        {
            LightsOn = true;
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


        // COUPURE DE COURANT

        if (CurrentEnergy < 0)
        {
            LightsOn = false;
        }
        

        // DRIFT

        Drifting = TurningButton1;

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
