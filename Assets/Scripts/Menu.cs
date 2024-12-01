using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   
    public void ChooseLevel()
   {
    SceneManager.LoadScene("Level");
   }
   public void PlayHardGame()
   {
    SceneManager.LoadScene("GameKho");
   }
   public void PlayEasyGame()
   {
    SceneManager.LoadScene("GameDe");
   }
   public void PlayGameNPC()
   {
    SceneManager.LoadScene("NPC");
   }
   public void QuitGame()
   {
    Application.Quit();
   }
   public void TutorialGame()
   {
    SceneManager.LoadScene("Tutorial");
   }
    public void BackMainMenu()
   {
    SceneManager.LoadScene("Menu");
   }
}
