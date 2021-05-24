using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  [SerializeField] float speed;

  // Start is called before the first frame update
  void Start()
  {
    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
  }
}
