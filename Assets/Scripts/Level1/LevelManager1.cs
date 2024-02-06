using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager1 : MonoBehaviour
{

    
        public bool level2unlocked;
        public bool level3unlocked;
        public bool level4unlocked;

        public CoalGoldManager manager;
        public IapManager apManager;

        void Start()
        {
            level2unlocked = PlayerPrefs.GetInt("level2Unlocked", 0) == 1;
            level3unlocked = PlayerPrefs.GetInt("level3Unlocked", 0) == 1;
            level4unlocked = PlayerPrefs.GetInt("level4unlocked", 0) == 1;



       

    }

    void Update()
    
    {
            if (manager.goldAmount >= 2500)
            {
                if (!level2unlocked)
                {
                    manager.goldAmount = 0;
                    PlayerPrefs.DeleteAll();
                    level2unlocked = true;
                    PlayerPrefs.SetInt("level2Unlocked", 1);

                }


            if (apManager.purchased)
            {
                PlayerPrefs.SetInt("Purchased", 1);
            }

            PlayerPrefs.Save();



            }

        if (level2unlocked && !level3unlocked && !level4unlocked)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (level3unlocked && !level4unlocked)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (level4unlocked)
        {
            SceneManager.LoadScene("Level4");

        }

    }

    private void OnDestroy()
    {
       // PlayerPrefs.DeleteAll();
    }


}




