using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiHandler : MonoBehaviour
{
   public String currentPlayer;
   public Text score;
   public Text highScoreText;
   public int pointsTotal;
   
   public static Text highScore;
   private void Awake()
   {
      highScore = highScoreText;
      currentPlayer = MainMenuHandler.userName;
      score.text = currentPlayer +" : " +pointsTotal;
   }

   public void OnReturnToMenu()
   {
      SceneManager.LoadScene(0);
   }
   
   
}
