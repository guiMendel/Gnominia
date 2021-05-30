using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    // Attack if is defender
    if (other.GetComponent<Defender>())
    {
      GetComponent<Attacker>().Attack(other.gameObject);
    }
  }
}
