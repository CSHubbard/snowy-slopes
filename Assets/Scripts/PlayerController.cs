using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float torqueAmount = 10.0f;
  private Rigidbody2D rb2d;

  private KeyCode keyInput;

  // Start is called before the first frame update
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      keyInput = KeyCode.LeftArrow;
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      keyInput = KeyCode.RightArrow;
    }
  }

  void FixedUpdate()
  {
    if (keyInput == KeyCode.LeftArrow)
    {
      rb2d.AddTorque(torqueAmount);
    }
    else if (keyInput == KeyCode.RightArrow)
    {
      rb2d.AddTorque(-torqueAmount);
    }
  }
}
