using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float torqueAmount = 15.0f;
  [SerializeField] float boostSpeed = 25f;
  [SerializeField] float baseSpeed = 15f;
  private bool canMove = true;

  private Rigidbody2D rb2d;
  private SurfaceEffector2D surfaceEffector2D;

  private KeyCode keyInput;

  // Start is called before the first frame update
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
    surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (canMove)
    {
      GetKeyInput();
      RespondToBoost();
    }
  }

  void FixedUpdate()
  {
    if (canMove)
    {
      RotatePlayer();
      keyInput = KeyCode.None;
    }
  }

  public void DisableControls()
  {
    canMove = false;
  }

  private void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      surfaceEffector2D.speed = boostSpeed;
    }
    else
    {
      surfaceEffector2D.speed = baseSpeed;
    }
  }

  private void GetKeyInput()
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

  private void RotatePlayer()
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
