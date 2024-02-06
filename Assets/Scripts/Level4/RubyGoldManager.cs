using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RubyGoldManager : MonoBehaviour
{

    public int goldAmount = 0;
    public TMP_Text coinText;
    



    void Start()
    {
        goldAmount = PlayerPrefs.GetInt("gold", goldAmount);
      
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = goldAmount.ToString();
        

     
    
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("gold", goldAmount);
        PlayerPrefs.Save();
    }




}
