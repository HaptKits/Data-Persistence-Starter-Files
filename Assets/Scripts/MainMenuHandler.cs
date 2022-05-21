using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
  public static String userName;
  public TMP_InputField input;
  public TMP_Text currentHighScore;
  private void Start()
  { 
   SaveAndLoad.LoadHighScore();
    input = GetComponentInChildren<TMP_InputField>();
    var se = new TMP_InputField.SubmitEvent();
    se.AddListener(StoreSubmitted);
    input.onEndEdit = se;

    if (SaveAndLoad.currentNameHighScore != null)
    {
      currentHighScore.text =
        $"Current Highest Score : {SaveAndLoad.currentSavedHighScore} : {SaveAndLoad.currentNameHighScore}";
    } else
    {
      currentHighScore.text = $"PlAY A GAME TO CLAIM THE HIGHEST SCORE";
    }
  }


  private void StoreSubmitted(String input)
  {
    Debug.Log(input);
    userName = input;
    Debug.Log(userName);
  }

  public void StartGame()
  {
    SceneManager.LoadScene(1);
  }

  public void Exit()
  {
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
Application.Quit
#endif
  }
}