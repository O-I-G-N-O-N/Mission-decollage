using System.Collections;
using UnityEngine;

public class SpaceAmbienceManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource spaceAmbience; // assign your looping space sound here
    public float fadeDuration = 2f;   // duration for fade in/out

    private bool isPlaying = false;

    void Start()
    {
        if (spaceAmbience != null)
        {
            spaceAmbience.loop = true;
            spaceAmbience.volume = 0f;
        }
    }

    /// <summary>
    /// Start playing the space ambience with optional fade in
    /// </summary>
    public void PlayAmbience()
    {
        if (spaceAmbience == null || isPlaying) return;

        spaceAmbience.Play();
        StartCoroutine(FadeVolume(spaceAmbience, 0f, 1f, fadeDuration));
        isPlaying = true;
    }

    /// <summary>
    /// Stop playing the space ambience with optional fade out
    /// </summary>
    public void StopAmbience()
    {
        if (spaceAmbience == null || !isPlaying) return;

        StartCoroutine(FadeOutAndStop(spaceAmbience, fadeDuration));
        isPlaying = false;
    }

    /// <summary>
    /// Smoothly fade volume from start to end
    /// </summary>
    private IEnumerator FadeVolume(AudioSource source, float start, float end, float duration)
    {
        float t = 0f;
        source.volume = start;

        while (t < duration)
        {
            t += Time.deltaTime;
            source.volume = Mathf.Lerp(start, end, t / duration);
            yield return null;
        }

        source.volume = end;
    }

    /// <summary>
    /// Fade out and stop the AudioSource
    /// </summary>
    private IEnumerator FadeOutAndStop(AudioSource source, float duration)
    {
        yield return FadeVolume(source, source.volume, 0f, duration);
        source.Stop();
    }
}
