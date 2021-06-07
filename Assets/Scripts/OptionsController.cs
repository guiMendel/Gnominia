using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
  // stored refs
  [SerializeField] Slider volumeSlider;
  [SerializeField] Slider difficultySlider;
  LevelLoader levelLoader;
  MusicPlayer musicPlayer;

  public void SaveAndBack() {
    PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    PlayerPrefsController.SetDifficulty(difficultySlider.value);
    levelLoader.LoadStartMenu();
  }

  public void ResetSettings() {
    volumeSlider.value = PlayerPrefsController.DEFAULT_VOLUME;
    difficultySlider.value = PlayerPrefsController.DEFAULT_DIFFICULTY;
  }

  // Start is called before the first frame update
  void Start()
  {
    // Update sliders
    volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    difficultySlider.value = PlayerPrefsController.GetDifficulty();

    // Get refs
    musicPlayer = FindObjectOfType<MusicPlayer>();
    levelLoader = FindObjectOfType<LevelLoader>();
  }

  // Update is called once per frame
  void Update()
  {
    // Synchronize configs
    musicPlayer?.SetVolume(volumeSlider.value);
  }
}
