using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI textScore;
[SerializeField]  private TextMeshProUGUI textBest;
[SerializeField]  private TextMeshProUGUI textLevel;
   

    // Update is called once per frame
    void Update()
    {
        textBest.text = "Best: " + GameManager.singleton.best;
        textScore.text = "Score: " + GameManager.singleton.score;
        textLevel.text = "Level: " + GameManager.singleton.level;
    }
}
 