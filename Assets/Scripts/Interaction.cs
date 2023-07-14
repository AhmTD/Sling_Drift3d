using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{

    public GameObject[] ruts;
    LevelManager levelManager;

    private void Awake()
    {
        for (int i = 0; i < ruts.Length; i++)
        {
            ruts[i].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "N90")
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        else if (other.gameObject.tag == "0")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else if (other.gameObject.tag == "180")
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        else if (other.gameObject.tag == "180")
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (other.gameObject.tag == "Drift")
        {
            for (int i = 0; i < ruts.Length; i++)
            {
                ruts[i].SetActive(true);
            }
        }

        else if (other.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (other.CompareTag("Finish"))
        {
            int levelNumber = int.Parse(other.gameObject.name);
            PlayerPrefs.SetInt("ReceiveLevelNumber",levelNumber);
            SceneManager.LoadScene("LevelSelected");
          
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drift")
        {
            for (int i = 0; i < ruts.Length; i++)
            {
                ruts[i].SetActive(false);
                ruts[i].GetComponent<TrailRenderer>().ResetBounds();
            }
        }
    }


}
