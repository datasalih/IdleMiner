using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager2 : MonoBehaviour
{

    public bool level3unlocked;
    public GoldManager manager;
    public IapManager apManager;



    private void Start()
    {
        level3unlocked = PlayerPrefs.GetInt("level3Unlocked", 0) == 1;


   
 
    }

    void Update()
    {
        if (manager.goldAmount >= 10000 )
        {
    


            if (!level3unlocked)
            {
                manager.goldAmount = 0;
                PlayerPrefs.DeleteAll();
                level3unlocked = true;
                PlayerPrefs.SetInt("level3Unlocked", 1);


            }


            if (apManager.purchased)
            {
                PlayerPrefs.SetInt("Purchased", 1); // Set "Purchased" to 1
            }


            PlayerPrefs.Save();
        }



        if (level3unlocked)
        {
            SceneManager.LoadScene("Level3");
        }





    }



}
