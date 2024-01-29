using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class IapManager : MonoBehaviour
{
    private string noads = "com.hypersengames.idleminermanager.noads";
    private GameObject iapbtn;

    public bool purchased;
 

    private void Start()
    {
        // Initialize the purchased state from PlayerPrefs
        purchased = PlayerPrefs.GetInt("Purchased", 0) == 1;

        iapbtn = GameObject.FindGameObjectWithTag("noadsbtn");

        // Disable the button if the product has already been purchased
        if (purchased)
        {
            iapbtn.SetActive(false);
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == noads)
        {
            purchased = true;
            iapbtn.SetActive(false);
            PlayerPrefs.SetInt("Purchased", 1);
            PlayerPrefs.Save();
        }
    }


}
