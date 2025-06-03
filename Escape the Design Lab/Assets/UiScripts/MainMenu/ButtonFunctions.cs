using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Screens")]
    public GameObject[] menuScreens;
    [Header("Audio")]
    public AudioSource menuAudioSource;
    public AudioClip hoverAudio;
    public AudioClip clickAudio;
    public void EnterAudio()
    {
        menuAudioSource.clip = hoverAudio;
        menuAudioSource.Play();
    }
    public void SettingsScreenActive()
    {
        menuScreens[0].SetActive(true);
        menuScreens[1].SetActive(false);

        menuAudioSource.clip = clickAudio;
        menuAudioSource.Play();
    }
    public void CreditsScreenActive()
    {
        menuScreens[1].SetActive(true);
        menuScreens[0].SetActive(false);

        menuAudioSource.clip = clickAudio;
        menuAudioSource.Play();
    }
}
