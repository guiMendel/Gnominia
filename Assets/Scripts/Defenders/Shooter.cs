using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] Projectile projectile;
  [SerializeField] Transform launchPosition;

  public void Shoot() {
    Projectile instance = Instantiate(projectile, launchPosition.position, launchPosition.rotation) as Projectile;
    instance.transform.parent = transform;
  }
  
}
