using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    public GameObject Rocket;
    public GameObject Camera;

    [Header("Particles")]
    public ParticleSystem LeftFire;
    public ParticleSystem MainFire;
    public ParticleSystem RightFire;
    public ParticleSystem LeftPivot;
    public ParticleSystem RightPivot;

    [Header("UI Sliders")]
    public Slider LeftSlider;
    public Slider RightSlider;
    public Slider MainSlider;
    public Slider PivotSlider;

    [Header("Forces")]
    public float MainReactorForce = 4f;
    public float BaseReactorForce = 10f;
    public float SideReactorForce = 10f;
    public float rotationSpeed = 90f;

    [SerializeField] float torqueForce = 0.2f;
    [SerializeField] float torqueDamp = 0.98f;

    [Header("Audio")]
    public AudioSource MainEngineAudio;
    public AudioSource LeftEngineAudio;
    public AudioSource RightEngineAudio;

    [Range(0f, 1f)] public float maxMainVolume = 1f;
    [Range(0f, 1f)] public float maxSideVolume = 0.6f;
    public float minPitch = 0.8f;
    public float maxPitch = 1.3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
    }

    public static float Proportion(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return Mathf.Clamp(
            ((value - inputMin) / (inputMax - inputMin) * (outputMax - outputMin) + outputMin),
            outputMin,
            outputMax
        );
    }

    void FixedUpdate()
    {
        float MainValue = Proportion(MainSlider.value, 0f, 1f, 0f, 9f);
        float RightValue = Proportion(RightSlider.value, 0f, 1f, 0f, 0.2f);
        float LeftValue = Proportion(LeftSlider.value, 0f, 1f, 0f, 0.2f);
        float PivotValue = Proportion(PivotSlider.value, 0f, 1f, -0.6f, 0.6f);

        // --- CAMERA STABILIZATION ---
        Quaternion invertedRotation = Quaternion.Inverse(rb.transform.localRotation);

        Camera.transform.localRotation = Quaternion.RotateTowards(
            Camera.transform.localRotation,
            invertedRotation,
            rotationSpeed * Time.deltaTime
        );

        // --- FORCES ---
        rb.AddForce(transform.forward * MainValue, ForceMode.Acceleration);

        rb.AddTorque(Vector3.forward * -LeftValue, ForceMode.Acceleration);
        rb.AddForce(transform.forward * LeftValue * 20f, ForceMode.Acceleration);

        rb.AddTorque(Vector3.forward * RightValue, ForceMode.Acceleration);
        rb.AddForce(transform.forward * RightValue * 20f, ForceMode.Acceleration);

        // --- PARTICLES ---
        HandleParticles(MainValue, LeftValue, RightValue, PivotValue);

        // --- AUDIO ---
        HandleEngineAudio(
            MainEngineAudio, MainSlider.value, maxMainVolume,
            LeftEngineAudio, LeftSlider.value, maxSideVolume,
            RightEngineAudio, RightSlider.value, maxSideVolume
        );

        rb.angularVelocity *= torqueDamp;
    }

    // ===================== PARTICLES =====================
    void HandleParticles(float main, float left, float right, float pivot)
    {
        if (main > 0f) MainFire.Play(); else MainFire.Stop();
        if (left > 0f) LeftFire.Play(); else LeftFire.Stop();
        if (right > 0f) RightFire.Play(); else RightFire.Stop();

        if (pivot > 0.2f)
        {
            RightPivot.Play();
            rb.AddTorque(Vector3.forward * pivot, ForceMode.Acceleration);
        }
        else
        {
            RightPivot.Stop();
        }

        if (pivot < -0.2f)
        {
            LeftPivot.Play();
            rb.AddTorque(Vector3.forward * pivot, ForceMode.Acceleration);
        }
        else
        {
            LeftPivot.Stop();
        }
    }

    // ===================== AUDIO =====================
    void HandleEngineAudio(
        AudioSource mainAudio, float mainPower, float mainMaxVol,
        AudioSource leftAudio, float leftPower, float sideMaxVol,
        AudioSource rightAudio, float rightPower, float sideMaxVol2
    )
    {
        HandleSingleEngine(mainAudio, mainPower, mainMaxVol);
        HandleSingleEngine(leftAudio, leftPower, sideMaxVol);
        HandleSingleEngine(rightAudio, rightPower, sideMaxVol2);
    }

    void HandleSingleEngine(AudioSource audio, float power, float maxVol)
    {
        if (power > 0.01f)
        {
            if (!audio.isPlaying)
                audio.Play();

            audio.volume = power * maxVol;
            audio.pitch = Mathf.Lerp(minPitch, maxPitch, power);
        }
        else
        {
            audio.Stop();
        }
    }
}
