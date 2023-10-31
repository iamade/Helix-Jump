using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    if(GameManager.singleton.currentStage >= 2){
      FindObjectOfType<BallController>().AddAnotherBall();
      if(collision.transform.GetComponent<Goal>()){
        GameManager.singleton.NextLevel();
      }
    }else {
      GameManager.singleton.NextLevel();
    }
   
  }
}
