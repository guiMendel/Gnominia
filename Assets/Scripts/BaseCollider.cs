using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCollider : MonoBehaviour
{
  List<Action<Attacker>> collisionObservers;

  private void Awake() {
    collisionObservers = new List<Action<Attacker>>();
  }

  public void OnCollide(Action<Attacker> action) { collisionObservers.Add(action); }

  void AlertObservers(Attacker attacker)
  {
    foreach (var observerAction in collisionObservers)
    {
      try
      {
        observerAction(attacker);
      }
      // If observer is dead, dont bother
      catch (MissingReferenceException)
      {
        Debug.Log("Omae wa, mou shindeiru");
        continue;
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    // Check if it's an attacker
    Attacker attacker = other.GetComponent<Attacker>();
    if (attacker)
    {
      AlertObservers(attacker);
    }

    // Detroy the object
    Destroy(other.gameObject);
  }
}
