
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))] 
public class AnomalySoundFlicker : MonoBehaviour
{
    private Light localLight;
    private AudioSource audioSource;
    private Color originalColor;

    [Header("Flicker Burst Settings")]
    public float flickerSpeed = 0.05f;
    public int blinkCount = 8;
    public Color flickerColor = Color.red;

    [Header("Sound Settings")]
    public AudioClip flickerSound;
    [Range(0, 1)] public float volume = 0.5f;

    [Header("Timing Between Bursts")]
    public float minWaitTime = 5.0f;
    public float maxWaitTime = 15.0f;

    void Start()
    {
        localLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        originalColor = localLight.color;

        StartCoroutine(AnomalousSoundRoutine());
    }

    IEnumerator AnomalousSoundRoutine()
    {
        while (true)
        {
            localLight.enabled = true;
            localLight.color = originalColor;

            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            for (int i = 0; i < blinkCount; i++)
            {
                localLight.color = (localLight.color == originalColor) ? flickerColor : originalColor;
                localLight.enabled = !localLight.enabled;

                // Play the sound every time the light state changes
                if (flickerSound != null)
                {
                    audioSource.PlayOneShot(flickerSound, volume);
                }

                yield return new WaitForSeconds(flickerSpeed);
            }

            localLight.enabled = true;
            localLight.color = originalColor;
        }
    }
}