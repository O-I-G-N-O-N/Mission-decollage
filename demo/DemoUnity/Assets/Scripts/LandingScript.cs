using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LandingScript : MonoBehaviour
{
    public ParticleSystem MainFire;
    
    public GameObject Astronaut;
    public GameObject SpeechBubble;
    public TextMeshProUGUI ScoreText;
    public float Score;
    public float fadeSpeed = 0.5f;
    public Transform fadeImage;
    public Animator FadeIn;
    public AudioSource sonVictoire;
    // Start is called before the first frame update

       [Header("Propulseur Audio")]
    public AudioSource propulseurLoop;

    void Start()
    {
        FadeIn.SetTrigger("TriggerFade");
        AudioListener.volume = 1f;
            if (GameManager.Instance != null)
        {

            Score = GameManager.Instance.Score;

            Score = Mathf.Round(Score * 10f) / 10f;
        }
        else
        {
            Score = 0f;
        }

        ScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireStart()
    {
        MainFire.Play();
        propulseurLoop.Play();
    }
    
    public void EndGame()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    public void FireStop()
    {
        MainFire.Stop();
        propulseurLoop.Stop();
    }

    public void AstronautAppear()
    {
        Astronaut.SetActive(true);
    }

    public void FinalScore()
    {
        sonVictoire.Play();
        SpeechBubble.SetActive(true);
    }

    public void ScoreDisplay()
    {
        ScoreText.text = "Score: " + Score.ToString("F1");
    }

    IEnumerator FadeAndLoadScene()
    {
        float targetY = 260f; // The Y position we want to move to
        Vector3 startPos = fadeImage.position;
        Vector3 targetPos = new Vector3(startPos.x, targetY, startPos.z);

        while (Mathf.Abs(fadeImage.position.y - targetY) > 0.01f)
        {
            // Smoothly move towards the target position
            fadeImage.position = Vector3.MoveTowards(fadeImage.position, targetPos, 500f * Time.deltaTime);
            yield return null; // Wait for next frame
        }

        // Ensure exact position
        fadeImage.position = targetPos;

        // Optional small delay
        yield return new WaitForSeconds(0.1f);

        // Load the next scene
        SceneManager.LoadScene("ReLaunchCinematic");
    }
}
