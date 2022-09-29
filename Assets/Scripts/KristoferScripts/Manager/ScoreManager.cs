using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   [Header("Text Components")]
   public TMP_Text playerScoreText;
   public TMP_Text saboteurScoreText;
   
   public static ScoreManager instance;
   
   [Header("Score Variables")]
   public static int playerScore;
   public static int saboteurScore;

   void Awake()
   {
      if (instance == null)
      {
         instance = this;
            
      }
      else
      {
         Debug.LogError("No ScoreManager");
      }
      
      
      
      
   }
   
   void Start()
   {
      playerScore = 0;
      saboteurScore = 0;
      
      playerScoreText.text = playerScore.ToString();
      saboteurScoreText.text = saboteurScore.ToString();
       

   }
   

   public void AddPlayerScore()
   {
       playerScore++;
       playerScoreText.text = playerScore.ToString();
       PlayerPrefs.SetInt("playerScore", playerScore);
       PlayerPrefs.Save();
   }

   public void AddSaboteurScore()
   {
      saboteurScore++;
      saboteurScoreText.text = saboteurScore.ToString();
      PlayerPrefs.SetInt("saboteurScore", saboteurScore);
      PlayerPrefs.Save();


   }
   //When Saboteur kill all players
   public void SaboteurKillsPlayer()
   {
      if (saboteurScore >= ((PlayerManager.instance._players.Count -1) * SettingHolder.Instance._startingHealth))
      {
                  
         saboteurScore += 10;
         saboteurScoreText.text = saboteurScore.ToString();
         
         PlayerPrefs.SetInt("saboteurScore", saboteurScore);
         PlayerPrefs.Save();
         var executeAfterAnimation = countdown.instance.ExecuteAfterAnimation(3);
         StartCoroutine(executeAfterAnimation);
      }
      
   }
   
   public void ResetScore()
   {
      PlayerPrefs.DeleteKey("saboteurScore");
      PlayerPrefs.DeleteKey("playerScore");

   }

   
}
