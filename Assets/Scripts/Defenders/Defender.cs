using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
  // Determines the offset when placing this defender
  [SerializeField] int cost = 2;

  public int GetCost() { return cost; }
}
