using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    // Jump if is wall
    if (other.GetComponent<Wall>())
    {
      GetComponent<Animator>().SetTrigger("jump");
    }

    // Attack if is defender
    else if (other.GetComponent<Defender>())
    {
      GetComponent<Attacker>().StartAttacking(other.gameObject);
    }
  }
}
