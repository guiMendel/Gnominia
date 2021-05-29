using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrencyManager : MonoBehaviour
{
  [SerializeField] int count = 3;
  TextMeshProUGUI textComponent;

  // Start is called before the first frame update
  void Start()
  {
    textComponent = GetComponent<TextMeshProUGUI>();
    UpdateText();
  }

  private void UpdateText()
  {
    textComponent.text = count.ToString();
  }

  public int UpdateBy(int amount)
  {
    if (amount + count < 0) throw new InsufficientFundsException("Not enough currency!");

    count += amount;
    UpdateText();
    return count;
  }

  // Indicates if there are enough funds for a certain amount
  public bool Affords(int amount) { return count >= amount; }
}