using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager3 : MonoBehaviour
{

    public bool level4unlocked;
    public DiamondGoldManager manager;
    public IapManager apManager;



    private void Start()
    {
        level4unlocked = PlayerPrefs.GetInt("level4unlocked", 0) == 1;


   
 
    }

    void Update()
    {
        if (manager.goldAmount >= 30000 )
        {
    


            if (!level4unlocked)
            {
                manager.goldAmount = 0;
                PlayerPrefs.DeleteAll();
                level4unlocked = true;
                PlayerPrefs.SetInt("level4unlocked", 1);

                if (level4unlocked)
                {
                    SceneManager.LoadScene("Level4");
                }


            }


            if (apManager.purchased)
            {
                PlayerPrefs.SetInt("Purchased", 1); // Set "Purchased" to 1
            }


            PlayerPrefs.Save();
        }



       




    }



}
