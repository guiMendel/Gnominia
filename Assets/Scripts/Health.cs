using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] int health = 100;
  [SerializeField] GameObject deathVFX;
  [SerializeField] float VFXDuration = 4f;

  // List of observers of this character's death
  List<Action> deathObservers;

  private void Awake() {
    deathObservers = new List<Action>();
  }

  public void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0) Die();
  }

  private void Die()
  {
    // Alert all observers
    alertDeathObservers();

    // FX
    if (deathVFX)
    {
      var vfx = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
      Destroy(vfx, VFXDuration);
    }

    Destroy(gameObject);
  }

  public void OnDeath(Action action)
  {
    deathObservers.Add(action);
  }

  private void alertDeathObservers()
  {
    foreach (Action observerAction in deathObservers) {
      try {
        observerAction();
      }
      // If observer is dead, dont bother
      catch (MissingReferenceException) {
        Debug.Log("Omae wa mou, shindeiru");
        continue;
      }
    }
  }
}
