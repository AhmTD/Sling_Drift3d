using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnClickStart()
    {
        int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneBuildIndex);
        }
        else
        {
            Debug.LogError("Ge�erli sahnenin bir sonraki sahne index'i ge�erli sahne say�s�n� a��yor.");
        }
    }
    public void LoadLevel(int levelNumber)
    {
 
      SceneManager.LoadScene("Level_" + levelNumber);
    }






}
