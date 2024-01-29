using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoalGoldManager : MonoBehaviour
{

    public int goldAmount;
    public TMP_Text coinText;

    void Start()
    {
        // Load the saved goldAmount from PlayerPrefs
        goldAmount = PlayerPrefs.GetInt("gold", goldAmount);

        // Update the UI with the loaded goldAmount
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = goldAmount.ToString();
    }

    // Save the goldAmount to PlayerPrefs when the object is destroyed
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("gold", goldAmount);
        PlayerPrefs.Save();
    }

    // Function to update the UI with the current goldAmount
 
}