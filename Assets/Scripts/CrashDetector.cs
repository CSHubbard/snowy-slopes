using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float respawnDelay = .5f;
  [SerializeField] ParticleSystem deathEffect;
  [SerializeField] AudioClip deathSFX;
  private bool playerIsAlive = true;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (playerIsAlive && other.tag == "Ground")
    {
      FindObjectOfType<PlayerController>().DisableControls();
      deathEffect.Play();
      GetComponent<AudioSource>().PlayOneShot(deathSFX, .25f);
      Invoke("ReloadScene", respawnDelay);
      playerIsAlive = false;
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
