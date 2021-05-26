using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accumulator : MonoBehaviour
{
  [SerializeField] int accumulationAmount = 1;
  CurrencyManager currencyManager;

  private void Start()
  {
    currencyManager = FindObjectOfType<CurrencyManager>();
  }

  public void Accumulate()
  {
    currencyManager.UpdateBy(accumulationAmount);
  }
}
