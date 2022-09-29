using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public TMP_Text saboteurScoreText;
   
    //Total Score in See Results Scene
    void Start()
    {
        playerScoreText.text = PlayerPrefs.GetInt("playerScore").ToString();
        saboteurScoreText.text = PlayerPrefs.GetInt("saboteurScore").ToString();
        
        
    }

}
