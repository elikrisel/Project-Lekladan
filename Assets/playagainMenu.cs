using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playagainMenu : MonoBehaviour
{

    public void PlayGame ()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        ScoreManager.instance.ResetScore();
    }

    public void BackToMenu ()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
        ScoreManager.instance.ResetScore();
    }

    public void SeeResults()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Results);
        Time.timeScale = 1;

    }

    
    
        public void QuitGame()
    {
        Application.Quit();
    }
    
        
    
}
