using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatEnergy : MonoBehaviour
{
    Coroutine HeatRoutine;
    Coroutine ColdRoutine;
    Coroutine GameOverRoutine;
    public static HeatEnergy Instance;

    [Header("UI")]

    public Slider HeatSlider;
    public Slider EnergySlider;
    public Slider HealthSlider;
    public Image LightOpacity;

    [Header("Scripts")]
    public FirstPersRocket FirstPersRocket;
    public Events Events;
    public Controllers Controllers;

    [Header("Values")]

    public float CurrentEngineHeat = 0;
    public float IncomingEngineHeat = 0;
    public float Health = 100;
    public float CurrentEnergy = 100;
    public bool LightsOn = true;
    public bool Drifting = false;
    public bool ShieldActive = false;
    public bool ShieldIsDisabled = false;
    public bool EngineIsOverheating = false;
    public bool RadarActive = false;
    public bool GameIsOver = false;
    private bool FadeStarted = false;
    private bool AlertIsFlashing = false;
    private bool PlayerIsCooling = false;
    private bool PlayerIsReloadingEnergy = false;
    [Header("Objects")]

    public GameObject Shield;
    public GameObject Radar;
    public GameObject HealthFill;
    public GameObject RocketTop;
    public GameObject RocketMovingTop;
    public GameObject RocketBottom;
    public ParticleSystem ExplosionParticles;
    public ParticleSystem RightFire;
    public ParticleSystem MainFire;
    public ParticleSystem LeftFire;
    public ParticleSystem MainGas;
    public ParticleSystem RightGas;
    public ParticleSystem LeftGas;
    public GameObject ThirdCamera;
    public Light CockpitLight;
    public Color LightOriginalColor;
    

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
        HealthSlider.value = Health/100;


        if (Controllers.FlipSwitch2) 
        {
             StartCoroutine(EjectionSequence());
        }

        if (CurrentEngineHeat >= 100) 
        {
             StartCoroutine(EngineOverheat());
             EngineIsOverheating = true;
        }

        if (CurrentEngineHeat < 100) 
        {
             EngineIsOverheating = false;
        }

        // VÉRIFIE QUE LE JOUEUR EST TOUJOURS VIVANT
        if (Health <= 0) 
        {
            GameIsOver = true;
        }

        if (GameIsOver && GameOverRoutine == null)
        {
            GameOverRoutine = StartCoroutine(GameOver());
        }


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
                PlayerIsCooling = true;
                CurrentEngineHeat -= 11f * Time.deltaTime;
                CurrentEnergy -= 11f * Time.deltaTime;
            }
            
        } else
        {
            PlayerIsCooling = false;
        }

        // BOUTON RECHARGEMENT D'ÉNERGIE 
        if (Controllers.TurningButton2 == true)
        {
            CurrentEngineHeat += 5f * Time.deltaTime;
            CurrentEnergy += 25f * Time.deltaTime;
            PlayerIsReloadingEnergy = true;
        } else
        {
            PlayerIsReloadingEnergy = false;
        }

        // EMPÊCHE LE JOUEUR DE MAINTENIR REFROIDISSEMENT ET RECHARGEMENT EN MÊME TEMPS
        if (PlayerIsReloadingEnergy && PlayerIsCooling)
        {
            Events.DialogueOccuring = true;
            Events.DialogueUI.text = "COURT CIRCUIT. NE PAS REFROIDIR LE MOTEUR LORSQUE LA BATTERIE RECHARGE";
            LightsOn = false;
            CurrentEngineHeat += 10f * Time.deltaTime;
            CurrentEnergy -= 35f * Time.deltaTime;
        } //else
        //{
            //Events.DialogueOccuring = false;
        //}

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

        // ACTIVE LE BOUCLIER LORSQUE LE BOUTON EST MAINTENU
        if (Controllers.Button1 == true && !ShieldIsDisabled)
        {
            ShieldActive = true;
        } else
        {
            ShieldActive = false;
        }

        // SYSTÈME PERMETTANT L'ACTIVATION DU BOUCLIER

        if (ShieldActive)
        {
            Shield.SetActive(true);
            CurrentEnergy -= 15f * Time.deltaTime;
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

        if (CurrentEnergy <= 0)
        {
            LightsOn = false;
            ShieldActive = false;
            ShieldIsDisabled = true;
        } else
        {
            ShieldIsDisabled = false;
        }
        

        // DRIFT

        Drifting = Controllers.TurningButton1;

        if (Drifting)
        {
            CurrentEngineHeat += 2f * Time.deltaTime;
        }




    }

        IEnumerator GameOver()
         {
            ThirdCamera.SetActive(true);
            yield return new WaitForSeconds(2f);
            RocketBottom.SetActive(false);
            RocketTop.SetActive(false);
            ExplosionParticles.Play();
            MainFire.Stop();
            LeftFire.Stop();
            RightFire.Stop();
            yield return null;
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


        IEnumerator EjectionSequence() 
    {
        ThirdCamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        MainGas.Play();
        LeftGas.Play();
        RightGas.Play();
        float duration = 5f;
        float timer = 0f;
    
        float startSpeed = 0.1f;   // fast at start
        float endSpeed = 0f;      // slow at end
    
        Vector3 direction = RocketMovingTop.transform.forward;
    
        while (timer < duration)
        {
            float t = timer / duration;              // 0 → 1
            float currentSpeed = Mathf.Lerp(startSpeed, endSpeed, t);
    
            RocketMovingTop.transform.position += direction * currentSpeed * Time.deltaTime;
    
            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("séquence finie");
        if (!FadeStarted && FirstPersRocket.SafeForEjection)
        {
            StartCoroutine(FadeToBlack());
            FadeStarted = true;
        } else
        {
            GameIsOver = true;
        }
        
    } 

            IEnumerator FadeToBlack()
    {
    FirstPersRocket.fadeImage.gameObject.SetActive(true);  // Make sure the fade image is active.
    Color startColor = FirstPersRocket.fadeImage.color;  // Get the initial color of the fade image.
    float t = 0f;

    // Start with a fully transparent image (alpha = 0).
    FirstPersRocket.fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

    // Fade in (transparent to black) and fade volume to 0 at the same time.
    float initialVolume = AudioListener.volume;  // Store the initial volume.
    while (t < FirstPersRocket.fadeDuration)
    {
        t += Time.deltaTime;  // Increment time.
        
        // Lerp the fade image alpha from 0 (transparent) to 1 (opaque).
        float alpha = Mathf.Lerp(0f, 1f, t / FirstPersRocket.fadeDuration);
        FirstPersRocket.fadeImage.color = new Color(
            startColor.r,
            startColor.g,
            startColor.b,
            alpha
        );

        // Lerp the volume from initialVolume to 0 (silent).
        AudioListener.volume = Mathf.Lerp(initialVolume, 0f, t / FirstPersRocket.fadeDuration);

        yield return null;  // Wait for the next frame.
    }

    // Ensure the fade image is fully opaque at the end.
    FirstPersRocket.fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    AudioListener.volume = 0f;  // Ensure the volume is fully muted.
    }

        IEnumerator EngineOverheat() 
    {
        if (EngineIsOverheating)
        {
            FlashStartAlert();
        }

            while (EngineIsOverheating)
        {
            Health -= 0.01f * Time.deltaTime;
            yield return null;
        }
    } 

        private void FlashStartAlert()
    {
        if (!AlertIsFlashing)
    {
        StartCoroutine(FlashAlert());
        AlertIsFlashing = true;
    }
    }

         private IEnumerator FlashAlert()
    {

        while (EngineIsOverheating)
        {
            // Interpolate between the current color and the target color
            CockpitLight.color = Color.red;
            yield return new WaitForSeconds(0.7f);
            CockpitLight.color = LightOriginalColor;
            yield return new WaitForSeconds(0.7f);
        }

        // Ensure the light ends with the original color
        CockpitLight.color = LightOriginalColor;
        AlertIsFlashing = false;
    }

}
