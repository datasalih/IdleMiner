using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;

public class CoalAdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";

    string _adUnitId;
    [SerializeField] Button _showAdButton;
    public int admoney = 10;
    private GameObject adbtn;
    public CoalGoldManager coalgmanager;
    public TMP_Text AdMoneyText;
    private int adWatchCount = 0;
    private const int maxAdViews = 3;
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

        if (adWatchCount >= maxAdViews)
        {
            adbtn = GameObject.FindGameObjectWithTag("AdButton");
            adbtn.GetComponent<Button>().interactable = false;
        }


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
        if (adWatchCount <= maxAdViews)
        {
            Advertisement.Show(_adUnitId, this);
            adWatchCount++;
            PlayerPrefs.SetInt("gold", coalgmanager.goldAmount);
            PlayerPrefs.Save();
        }
    
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
            coalgmanager.goldAmount += admoney;
            coalgmanager.coinText.text = coalgmanager.goldAmount.ToString();

            PlayerPrefs.SetInt("gold", coalgmanager.goldAmount);
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
        if (coalgmanager.goldAmount < 100)
        {
            admoney = 10;
            AdMoneyText.text = "+" + admoney;

        }
        else if (coalgmanager.goldAmount >= 100 && coalgmanager.goldAmount < 200)
        {
            admoney = 15;
            AdMoneyText.text = "+" + admoney;

        }
        else if (coalgmanager.goldAmount >= 200 && coalgmanager.goldAmount < 300)
        {
            admoney = 20;
            AdMoneyText.text = "+" + admoney;

        }

        else if (coalgmanager.goldAmount >= 300 && coalgmanager.goldAmount < 400)
        {
            admoney = 25;
            AdMoneyText.text = "+" + admoney;

        }

        else if (coalgmanager.goldAmount >= 400 && coalgmanager.goldAmount < 500)
        {
            admoney = 30;
            AdMoneyText.text = "+" + admoney;

        }
        else if (coalgmanager.goldAmount >= 500)
        {
            admoney = 40;
            AdMoneyText.text = "+" + admoney;

        }


    }





}
