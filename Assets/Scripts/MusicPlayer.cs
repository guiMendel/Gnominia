using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
  AudioSource audioSource;

  // singleton
  static bool instanceLoaded = false;

  private void Awake()
  {
    // Singleton
    if (instanceLoaded)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }

    instanceLoaded = true;

    DontDestroyOnLoad(gameObject);
  }

  // Start is called before the first frame update
  void Start()
  {
    audioSource = FindObjectOfType<AudioSource>();

    // Set volume
    SetVolume(PlayerPrefsController.GetMasterVolume());
  }

  public void SetVolume(float volume) { audioSource.volume = volume; }

}
