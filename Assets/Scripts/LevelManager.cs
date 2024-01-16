using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool nextlevelunlocked;
    public bool resetPlayerPrefsDone;
    public CoalGoldManager manager;

    private void Awake()
    {
        if (nextlevelunlocked)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    private void Start()
    {
        nextlevelunlocked = PlayerPrefs.GetInt("level2Unlocked", 0) == 1;
        resetPlayerPrefsDone = PlayerPrefs.GetInt("nextlevelunlocked", 0) == 1;
 
    }

    void Update()
    {
        if (manager.goldAmount >= 3000)
        {

            if (!resetPlayerPrefsDone)
            {
                PlayerPrefs.DeleteAll();
            }

            nextlevelunlocked = true;
            resetPlayerPrefsDone = true;

            PlayerPrefs.SetInt("level2Unlocked", 1);
            PlayerPrefs.SetInt("nextlevelunlocked", 1);

         

        }

   

        if (nextlevelunlocked)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    private void OnDestroy()
    {
      // PlayerPrefs.DeleteAll();
    }


}
