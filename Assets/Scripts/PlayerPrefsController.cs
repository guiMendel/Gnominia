using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
  const string MASTER_VOLUME_KEY = "master volume";
  const string DIFFICULTY_KEY = "difficulty";

  const float MIN_VOLUME = 0f;
  const float MAX_VOLUME = 1f;

  const float MIN_DIFFICULTY = 0.5f;
  const float MAX_DIFFICULTY = 2f;

  // Interface

  public const float DEFAULT_VOLUME = 0.5f;
  public const float DEFAULT_DIFFICULTY = 1f;

  public static void SetMasterVolume(float rawVolume)
  {
    SetConfiguration(MASTER_VOLUME_KEY, rawVolume, MIN_VOLUME, MAX_VOLUME);
  }

  public static void SetDifficulty(float rawDifficulty)
  {
    SetConfiguration(DIFFICULTY_KEY, rawDifficulty, MIN_DIFFICULTY, MAX_DIFFICULTY);
  }

  public static float GetMasterVolume() { return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, DEFAULT_VOLUME); }

  public static float GetDifficulty() { return PlayerPrefs.GetFloat(DIFFICULTY_KEY, DEFAULT_DIFFICULTY); }

  // Applies a scale to the difficulty before returning it
  public static float GetDownscaledDifficulty(float scale)
  {
    return Mathf.Min(scale, 1f) * (GetDifficulty() - 1f) + 1f;
  }

  private static void SetConfiguration(string configurationKey, float rawValue, float minValue, float maxValue)
  {
    float value = Mathf.Clamp(rawValue, minValue, maxValue);

    if (value != rawValue)
    {
      Debug.LogError("Tried to set \"" + configurationKey + "\" to invalid value " + rawValue);
    }

    PlayerPrefs.SetFloat(configurationKey, value);
  }
}
