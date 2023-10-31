using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
   
private bool ignoreNextCollision;
public Rigidbody rb; 
public float impulseForce = 5f;
private Vector3 startPos;
public int perfectPass = 0;
public bool isSuperSpeedActive;
public AudioClip bouncingSound;
public AudioClip crashSound;
private AudioSource ballAudio;


    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
        ballAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(ignoreNextCollision)
            return;

        if(isSuperSpeedActive){
            if(!collision.transform.GetComponent<Goal>()) {
                Destroy(collision.transform.parent.gameObject);
                Debug.Log("Destroying Platform");
            }
        }else {
        //Adding ResetLevel functionality via Deathpart - initialized when deathpart is hit.
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart)
            deathPart.HitDeathPart();
        }

        //Debug.Log("Ball touched something");

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
        ballAudio.PlayOneShot(bouncingSound);
    }

   private void Update() {
      if(perfectPass >= 3 && !isSuperSpeedActive) {
        isSuperSpeedActive = true;
        rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
      }
    }

    private void AllowCollision() {
        ignoreNextCollision = false;
        //1:28:12
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

    public void AddAnotherBall() {
        transform.position = startPos;
    }
}
