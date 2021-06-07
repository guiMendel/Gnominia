using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
  [Tooltip("Time in seconds this level takes to complete")]
  [SerializeField] float levelDuration = 60f;

  // state
  List<Action> timeoutObservers;

  // stored refs
  Slider slider;

  // INTERFACE

  public void OnTimeout(Action action) { timeoutObservers.Add(action); }

  private void Awake()
  {
    timeoutObservers = new List<Action>();
  }

  private void Start()
  {
    slider = GetComponent<Slider>();
    slider.value = 0;
  }

  public IEnumerator CountTime()
  {
    bool active = true;
    float startTime = Time.timeSinceLevelLoad;

    while (active)
    {
      float currentTime = Time.timeSinceLevelLoad - startTime;

      slider.value = currentTime / levelDuration;

      // Check if timer is up
      if (currentTime >= levelDuration)
      {
        active = false;
        AlertTimeoutObservers();
      }

      // Wait next frame
      yield return null;
    }

  }

  private void AlertTimeoutObservers()
  {
    foreach (Action observerAction in timeoutObservers)
    {
      try
      {
        observerAction();
      }
      // If observer is dead, dont bother
      catch (MissingReferenceException)
      {
        print("Omae wa, mou shindeiru");
        continue;
      }
    }
  }
}
