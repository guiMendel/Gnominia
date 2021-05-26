using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
  // Determines the offset when placing this defender
  [SerializeField] Vector2 placementOffset;
  [SerializeField] int cost = 2;

  public Vector2 GetPlacementOffset() { return placementOffset; }

  public int GetCost() { return cost; }
}
