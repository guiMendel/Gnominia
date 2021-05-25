using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
  // Determines the offset when placing this defender
  [SerializeField] Vector2 placementOffset;

  public Vector2 GetPlacementOffset() {
    return placementOffset;
  }
}
