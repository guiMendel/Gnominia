using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCollider : MonoBehaviour
{
  [SerializeField] int healthPoints = 3;

  public int GetHealthPoints() { return healthPoints; }

  private void OnTriggerEnter2D(Collider2D other)
  {
    // Check if it's an attacker
    if (other.GetComponent<Attacker>())
    {
      // Take damage
      healthPoints -= 1;

      if (healthPoints <= 0) LoseGame();
    }

    // Detroy the object
    Destroy(other.gameObject);
  }

  // Go back to first scene after loading screen
  private void LoseGame()
  {
    SceneManager.LoadScene(1);
  }
}
