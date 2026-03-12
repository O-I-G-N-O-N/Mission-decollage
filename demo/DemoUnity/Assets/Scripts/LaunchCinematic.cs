using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCinematic : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Rocket;
    public ParticleSystem LeftFire;
    public ParticleSystem MainFire;
    public ParticleSystem RightFire;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        
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

    // Continue rocket movement after side fires
    float continueDuration = 10f; // how long it continues
    float continueTime = 0f;
    float continueSpeed = 5f; // constant speed or can also ease

    while (continueTime < continueDuration)
    {
        
        float t2 = continueTime / continueDuration;
        float speedMultiplier2 = Mathf.SmoothStep(0f, 1f, t2);

        float AccelerationSpeed = 0f;
        AccelerationSpeed += 1f;

        Rocket.transform.position += new Vector3(0f, continueSpeed, 0f) * Time.deltaTime;

        continueTime += Time.deltaTime;
        continueSpeed += 2f * Time.deltaTime;
        yield return null;
    }
    


    }
}
