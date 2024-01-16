using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{

    public  int goldAmount = 0; // Make goldAmount static
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        goldAmount = PlayerPrefs.GetInt("gold", goldAmount);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = goldAmount.ToString();

    }



}
