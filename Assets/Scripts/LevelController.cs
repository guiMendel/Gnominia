using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  // state
  GameTimer gameTimer;
  AttackerSpawner attackerSpawner;

  private void Start()
  {
    gameTimer = FindObjectOfType<GameTimer>();
    attackerSpawner = FindObjectOfType<AttackerSpawner>();

    // Listen for timeout
    gameTimer.OnTimeout(FinishSpawning);
  }

  private void FinishSpawning()
  {
    // Stop spawning
    attackerSpawner.StopSpawning();

    // prepare to end level
    StartCoroutine(EndOfLevel());
  }

  private IEnumerator EndOfLevel()
  {
    // Wait until enemies are all dead
    yield return new WaitUntil(() => attackerSpawner.GetNumberOfEnemies() == 0);

    // Finish the level
    print("Yay its all done");
  }
}
