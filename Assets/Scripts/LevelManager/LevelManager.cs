using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Button[] levelButtons;
    private static int currentLevel = 0;
    int �ndex;


    private void Start()
    {

        for (int i = 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            string key = "ReceiveLevelNumber";
            PlayerPrefs.DeleteKey(key);

            for (int i = 1; i < levelButtons.Length; i++)
            {
                levelButtons[i].interactable = false;
            }

        }

        �ndex = PlayerPrefs.GetInt("ReceiveLevelNumber");
        ReceiveLevelNumber(�ndex);
        PlayerPrefs.GetInt("ReceiveLevelNumber", 0);
    }
    public void ReceiveLevelNumber(int levelNumber)
    {
        Debug.Log(levelNumber);
        LevelCompleted(levelNumber);
        currentLevel = levelNumber;
        if (currentLevel < levelButtons.Length)
        {
            levelButtons[currentLevel].interactable = true;
        }
    }

    private static void LevelCompleted(int completedLevel)
    {
        Debug.Log("Level " + completedLevel + " tamamland�!");
        // Di�er i�lemleri burada ger�ekle�tirin


    }
}
