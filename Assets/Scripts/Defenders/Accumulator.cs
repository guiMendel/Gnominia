using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accumulator : MonoBehaviour
{
  [SerializeField] int accumulationAmount = 1;
  [SerializeField] GameObject accumulationVFX;
  [SerializeField] float VFXDuration = 2f;
  CurrencyManager currencyManager;

  private void Start()
  {
    currencyManager = FindObjectOfType<CurrencyManager>();
  }

  public void Accumulate()
  {
    currencyManager.UpdateBy(accumulationAmount);

    // FX
    if (accumulationVFX)
    {
      Transform body = transform.Find("Body");
      var vfx = Instantiate(accumulationVFX, body.position, body.rotation);
      Destroy(vfx, VFXDuration);
    }
  }
}
