using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
  [SerializeField] Defender defender;

  private void OnMouseDown() {
    SpawnDefender(GetClickedSquare());
  }

  private Vector2 GetClickedSquare() {
    Vector2 clickScreenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    Vector2 clickPosition = Camera.main.ScreenToWorldPoint(clickScreenPosition);

    // Snap to one of the squares
    Vector2 clickSquare = SnapToSquares(clickPosition);
    
    return clickSquare;
  }

  private Vector2 SnapToSquares(Vector2 position)
  {
    return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
  }

  private void SpawnDefender(Vector2 position)
  {
    Instantiate(defender, position + defender.GetPlacementOffset(), Quaternion.identity);
  }
}
