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

  // INTERFACE

  public void OnTimeout(Action action) { timeoutObservers.Add(action); }

  private void Awake()
  {
    timeoutObservers = new List<Action>();
  }

  private void Start()
  {
    StartCoroutine(CountTime());
  }

  IEnumerator CountTime()
  {
    bool active = true;

    while (active)
    {
      GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelDuration;

      // Check if timer is up
      if (Time.timeSinceLevelLoad >= levelDuration)
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
        print("Omae wa mou, shindeiru");
        continue;
      }
    }
  }
}
