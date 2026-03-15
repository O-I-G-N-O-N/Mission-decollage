using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LaunchCinematic : MonoBehaviour
{
    public GameObject MainCamera;
    public Controllers Controllers;
    public GameObject Rocket;
    public ParticleSystem LeftFire;
    public ParticleSystem MainFire;
    public ParticleSystem RightFire;
    private float targetFadeAlpha = 0f;
    public float fadeSpeed = 0.5f;
    public Image fadeImage;
    public GameObject StartMenuUI;
    public bool GameStarted = false;
    public bool AnyKeyGotPressed = false;

    [Header("Audios")]
    public AudioSource ambienceTerre;
    public AudioSource propulseurLoop; 
    public AudioSource propulseurLoop2; 

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Launch());
        AudioListener.volume = 1f;
        ambienceTerre.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Controllers.Button1 || Controllers.Button2 || Controllers.Button3 || Controllers.Button4 || Controllers.Button5 || Controllers.Button6) && Controllers.FlipSwitch1 && Controllers.FlipSwitch3)
        {
            AnyKeyGotPressed = true;
        }

        if (!GameStarted && AnyKeyGotPressed)
        {
            StartMenuUI.SetActive(false);
            GameStarted = true;
            StartCoroutine(Launch());
        }

        if (fadeImage != null)
    {
        Color c = fadeImage.color;
        c.a = Mathf.MoveTowards(c.a, targetFadeAlpha, fadeSpeed * Time.deltaTime);
        fadeImage.color = c;
    }
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(1f);

    float duration = 3f;
    float time = 0f;

    Vector3 startPos = MainCamera.transform.position;
    //Vector3 RocketStartPos = Rocket.transform.position;
    Vector3 targetPos = startPos - new Vector3(0, 0, 2f);

    while (time < duration)
    {
        MainCamera.transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
        time += Time.deltaTime;
        yield return null;
    }

    yield return new WaitForSeconds(0.2f);

    float startLaunchTime = 0f;
    float duration2 = 2f;

    // Start main fire
    MainFire.Play();
    propulseurLoop.Play();

    // Initial launch with easing
    while (startLaunchTime < duration2)
    {
        float t = startLaunchTime / duration2; // 0 → 1
        float speedMultiplier = Mathf.SmoothStep(0f, 1f, t);

        Rocket.transform.position += new Vector3(0f, 2f * speedMultiplier, 0f) * Time.deltaTime;

        startLaunchTime += Time.deltaTime;
        yield return null;
    }

    // Activate side fires
    LeftFire.Play();
    RightFire.Play();
    propulseurLoop2.Play();

    // Continue rocket movement after side fires
    float continueDuration = 9f; // how long it continues
    float continueTime = 0f;
    float continueSpeed = 5f; // constant speed or can also ease
    bool FadeStarted = false;

    while (continueTime < continueDuration)
    {
        
        float t2 = continueTime / continueDuration;
        float speedMultiplier2 = Mathf.SmoothStep(0f, 1f, t2);

        float AccelerationSpeed = 0f;
        AccelerationSpeed += 1f;
        bool CamAnimationStarted = false;

        Rocket.transform.position += new Vector3(0f, continueSpeed, 0f) * Time.deltaTime;

        continueTime += Time.deltaTime;
        continueSpeed += 2f * Time.deltaTime;
        if (continueTime >= 3 && !CamAnimationStarted)
            {
                CamAnimationStarted = true;
                StartCoroutine(CamMoveDown());
            }

        if (continueTime >= 6f && !FadeStarted)
            {
                FadeStarted = true;
                StartCoroutine(FadeAndLoadScene());
            }
            
        yield return null;
    }
    }

    IEnumerator CamMoveDown()
    {
        float camMoveDuration = 3f;
    float camTime = 0f;

    Vector3 camStartPos = MainCamera.transform.position;
    Vector3 camTargetPos = camStartPos + new Vector3(0f, -4f, 0f);

    Quaternion camStartRot = MainCamera.transform.rotation;
    Quaternion camTargetRot = Quaternion.Euler(
        camStartRot.eulerAngles.x - 30f,
        camStartRot.eulerAngles.y,
        camStartRot.eulerAngles.z
    );

    while (camTime < camMoveDuration)
    {
        float t = camTime / camMoveDuration;

        MainCamera.transform.position = Vector3.Lerp(camStartPos, camTargetPos, t);

        // Rotate camera upward
        MainCamera.transform.rotation = Quaternion.Slerp(camStartRot, camTargetRot, t);

        camTime += Time.deltaTime;
        yield return null;
    }
    }

    IEnumerator FadeAndLoadScene()
{

    fadeImage.gameObject.SetActive(true);
    targetFadeAlpha = 1f;

    // Wait until fully black
    while (fadeImage.color.a < 1f)
    {
        yield return null;
    }
    yield return new WaitForSeconds(0.1f);

    SceneManager.LoadScene("Space");
}
}
