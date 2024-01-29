using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class DiamondAdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";

    string _adUnitId;
    [SerializeField] Button _showAdButton;
    public int admoney = 200;
    private GameObject adbtn;
    public DiamondGoldManager dmanager;
    public TMP_Text AdMoneyText;
    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Disable the button until the ad is ready to show:
        _showAdButton.interactable = false;

    }

    private void Update()
    {
        CoalUpdateAdMoney();

    }

    private void Start()
    {
        Advertisement.Load(_adUnitId, this);
        LoadAd();

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(_adUnitId, this);
    }

    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
        _showAdButton.interactable = true;

    }




    public void ShowRewardedAd()
    {


  
            Advertisement.Show(_adUnitId, this);
        adbtn = GameObject.FindGameObjectWithTag("AdButton");
        adbtn.GetComponent<Button>().interactable = false;


        CoalUpdateAdMoney();
        PlayerPrefs.SetInt("gold", dmanager.goldAmount);
        PlayerPrefs.Save();



    }

     

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowRewardedAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }
 

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            dmanager.goldAmount += admoney;
            dmanager.coinText.text = dmanager.goldAmount.ToString();

            PlayerPrefs.SetInt("gold", dmanager.goldAmount);
            PlayerPrefs.Save();

        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {

      

        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }


   


    void CoalUpdateAdMoney()
    {
        if (dmanager.goldAmount < 1000)
        {
            admoney = 75;
            AdMoneyText.text = "+225";

        }
        else if (dmanager.goldAmount >= 1000 && dmanager.goldAmount < 3000)
        {
            admoney = 100;
            AdMoneyText.text = "+300";

        }
        else if (dmanager.goldAmount >= 3000 && dmanager.goldAmount < 5000)
        {
            admoney = 125;
            AdMoneyText.text = "+375";

        }

        else if (dmanager.goldAmount >= 5000 && dmanager.goldAmount < 7000)
        {
            admoney = 150;
            AdMoneyText.text = "+450";

        }

        else if (dmanager.goldAmount >= 7000 && dmanager.goldAmount < 10000)
        {
            admoney = 200;
            AdMoneyText.text = "+600";

        }
        else if (dmanager.goldAmount >= 10000)
        {
            admoney = 250;
            AdMoneyText.text = "+750";

        }


    }





}
