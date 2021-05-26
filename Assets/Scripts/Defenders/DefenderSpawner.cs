using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
  // Selected defender
  Defender defender;

  // Selected defender button
  DefenderButton defenderButton;

  // Stored refs

  // Reference to currency
  CurrencyManager currencyManager;

  private void Start()
  {
    currencyManager = FindObjectOfType<CurrencyManager>();
  }

  // Attempts to select a defender prefab to be spawned on click, and it's button to deselect it
  // Returns true if it was successfully selected
  public bool SelectDefender(Defender newDefender, DefenderButton newDefenderButton)
  {
    if (!currencyManager.Affords(newDefender.GetCost())) return false;

    defender = newDefender;
    defenderButton = newDefenderButton;

    return true;
  }

  private void OnMouseDown()
  {
    SpawnDefender(GetClickedSquare());
  }

  private Vector2 GetClickedSquare()
  {
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
    if (!defender) return;

    try
    {
      // Discount defender cost
      currencyManager.UpdateBy(-defender.GetCost());

      Instantiate(defender, position + defender.GetPlacementOffset(), Quaternion.identity);
    }
    catch (InsufficientFundsException)
    {
      Debug.LogError("Attempted to place defender without enough funds");
    }

    // Deselect defender
    defender = null;
    defenderButton.Deselect();
  }
}
