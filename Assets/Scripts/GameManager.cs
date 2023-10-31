using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{

    public int best;
    public int score;
    public int level;
    public int currentStage = 0;
    public static GameManager singleton;
    public AudioClip passThroughSound;
     private AudioSource pTAudio;
    
    // Start is called before the first frame update
    void Awake()
    {
        Advertisement.Initialize("5460258");
        if(singleton == null)
            singleton = this;
        else if(singleton != this)
            Destroy(gameObject);
        best = PlayerPrefs.GetInt("Highscore");
       pTAudio = GetComponent<AudioSource>();
    }

    public void NextLevel(){
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
        // singleton.level = 0;
        level = currentStage + 1;
        Debug.Log("Next level called" + currentStage);
    }

    public void RestartLevel() {
        Debug.Log("Game Over");
        Advertisement.Show("5460258");
        // Android 5460258
        
        // Apple 5460259
        
        //Show ads
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd){
        score += scoreToAdd;
        pTAudio.PlayOneShot(passThroughSound);

        if(score > best){
            best = score;
            PlayerPrefs.SetInt("HighScore", score);
        } 
        //
        
    }
     
}
