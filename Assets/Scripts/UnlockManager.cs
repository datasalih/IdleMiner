using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    public BaseMiner1 miner1;
    public BaseMiner2 miner2;
    public BaseMiner3 miner3;
    public GoldManager goldmanager;
    public Managers manager;


    int shaft2Price = 25;
    int shaft3Price = 100;

    int autominingprice1 = 50;
    int autominingprice2 = 100;
    int aoutominingprice3 = 200;

    int speedprice1 = 15;
    int speedprice2 = 20;
    int speedprice3 = 25;

    int powerprice1 = 15;
    int powerprice2 = 20;
    int powerprice3 = 25;

    public int cps1 = 5;
    public int cps2 = 10;
    public int cps3 = 20;

    public bool shaft2Unlocked;
    public bool shaft3Unlocked;

    public  bool autounlocked1;
    public  bool autounlocked2;
    public  bool autounlocked3;

    GameObject Unlockables;
    GameObject UnlockButtons;

    public Button manager1btn;
    public Button manager2btn;
    public Button manager3btn;

    public TMP_Text speedprice1text;
    public TMP_Text speedprice2text;
    public TMP_Text speedprice3text;

    public TMP_Text powerprice1text;
    public TMP_Text powerprice2text;
    public TMP_Text powerprice3text;



    public TMP_Text cps_text1;
    public TMP_Text cps_text2;
    public TMP_Text cps_text3;





    private void Start()
    {
        Unlockables = GameObject.FindGameObjectWithTag("Unlockables");
        UnlockButtons = GameObject.FindGameObjectWithTag("UnlockButtons");

        shaft2Unlocked = PlayerPrefs.GetInt("shaft22", 0) == 1;
        shaft3Unlocked = PlayerPrefs.GetInt("shaft3",0) == 1;

        autounlocked1 = PlayerPrefs.GetInt("auto1denemea", 0) == 1;
        autounlocked2 = PlayerPrefs.GetInt("auto2", 0) == 1;
        autounlocked3 = PlayerPrefs.GetInt("auto3", 0) == 1;

        speedprice1 = PlayerPrefs.GetInt("speedprice1", speedprice1);
        speedprice2 = PlayerPrefs.GetInt("speedprice2", speedprice2);
        speedprice3 = PlayerPrefs.GetInt("speedprice3", speedprice3);

        powerprice1 = PlayerPrefs.GetInt("powerprice1", powerprice1);
        powerprice2 = PlayerPrefs.GetInt("powerprice2", powerprice2);
        powerprice3 = PlayerPrefs.GetInt("powerprice3", powerprice3);


        cps1 = PlayerPrefs.GetInt("cps1", cps1);
        cps2 = PlayerPrefs.GetInt("cps2", cps2);
        cps3 = PlayerPrefs.GetInt("cps3", cps3);


        if(shaft2Unlocked)
        {
            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(1).gameObject.SetActive(true);
            }
        }


        if(shaft3Unlocked)
        {
            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        if(autounlocked1)
        {
            manager1btn.interactable = false;
            miner1.MoveMiner1();
        }

        if(autounlocked2)
        {
            manager2btn.interactable = false;
            miner2.MoveMiner2();

        }
        if(autounlocked3)
        {
            manager3btn.interactable = false;
            miner3.MoveMiner3();
        }


    }

    private void Update()
    {
        cps_text1.text = cps1.ToString() + "/s";
        speedprice1text.text = speedprice1.ToString();

        if (miner1.miningspeed1 <= 0)
        {
            speedprice1text.text = "Max";
        }

        cps_text2.text = cps2.ToString() + "/s";
        speedprice2text.text = speedprice2.ToString();

        if (miner2.miningspeed2 <= 0)
        {
            speedprice2text.text = "Max";
        }

        cps_text3.text = cps3.ToString() + "/s";
        speedprice3text.text = speedprice3.ToString();

        if (miner3.miningspeed3 <= 0)
        {
            speedprice3text.text = "Max";
        }


        powerprice1text.text = powerprice1.ToString();
        powerprice2text.text = powerprice2.ToString();
        powerprice3text.text = powerprice3.ToString();

        if (miner1.miningpower1 >= 10)
        {
            powerprice1text.text = "Max";
        }

        if(miner2.miningpower2 >= 15)
        {
            powerprice2text.text = "Max";
        }

        if(miner3.miningpower3 >= 25)
        {
            powerprice3text.text = "Max";
        }

    }


    public void UnlockShaft2()
    {
        if (goldmanager.goldAmount >= shaft2Price)
        {
            shaft2Unlocked = true;
            goldmanager.goldAmount -= shaft2Price;
            PlayerPrefs.SetInt("gold", goldmanager.goldAmount);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("shaft22",1);

            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(0).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(1).gameObject.SetActive(true);
            }

        }

    }

    public void UnlockShaft3()
    {
        if (goldmanager.goldAmount >= shaft3Price)
        {
            shaft3Unlocked = true;
            goldmanager.goldAmount -= shaft3Price;
            PlayerPrefs.SetInt("gold", goldmanager.goldAmount);
            PlayerPrefs.SetInt("shaft3", 1);


            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

    }

    public void HireManager1()
    {
        if(goldmanager.goldAmount >= autominingprice1)
        {
            autounlocked1 = true;
            goldmanager.goldAmount -= autominingprice1;
            manager.hiremantext1.text = "Hired";
            PlayerPrefs.SetInt("auto1denemea", 1);
            PlayerPrefs.Save();
            manager1btn.interactable = false;
            miner1.MoveMiner1();
        }
    }

    public void HireManager2()
    {
        if (goldmanager.goldAmount >= autominingprice2)
        {
            autounlocked2 = true;
            goldmanager.goldAmount -= autominingprice2;
            manager.hiremantext2.text = "Hired";

            PlayerPrefs.SetInt("auto2", 1); // Use a different key for manager 2
            PlayerPrefs.Save();
            manager2btn.interactable = false;
            miner2.MoveMiner2();
        }
    }

    public void HireManager3()
    {
        if (goldmanager.goldAmount >= aoutominingprice3)
        {
            autounlocked3 = true;
            goldmanager.goldAmount -= aoutominingprice3;
            manager.hiremantext3.text = "Hired";

            PlayerPrefs.SetInt("auto3", 1); // Use a different key for manager 3
            PlayerPrefs.Save();
            manager3btn.interactable = false;
            miner3.MoveMiner3();
        }
    }


    public void UpgradeSpeed1()
    {
        if(goldmanager.goldAmount >= speedprice1)
        {
            goldmanager.goldAmount -= speedprice1;
            miner1.miningspeed1--;
            speedprice1 *= 2;
            speedprice1text.text = speedprice1.ToString();
            cps1++;
            cps_text1.text = cps1.ToString() + "/s";
            PlayerPrefs.SetInt("speed1", miner1.miningspeed1);
            PlayerPrefs.SetInt("speedprice1", speedprice1);
            PlayerPrefs.SetInt("cps1", cps1);
            PlayerPrefs.Save();
            
            if(miner1.miningspeed1 <= 0)
            {
                speedprice1text.text = "Max";
            }

        }
    }

    public void UpgradeSpeed2()
    {
        if (goldmanager.goldAmount >= speedprice2)
        {
            goldmanager.goldAmount -= speedprice2;
            miner2.miningspeed2--;
            speedprice2 *= 2;
            speedprice2text.text = speedprice2.ToString();
            cps2++;
            cps_text2.text = cps2.ToString() + "/s";
            PlayerPrefs.SetInt("speed2", miner2.miningspeed2);
            PlayerPrefs.SetInt("speedprice2", speedprice2);
            PlayerPrefs.SetInt("cps2", cps2);
            PlayerPrefs.Save();

            if (miner2.miningspeed2 <= 0)
            {
                speedprice2text.text = "Max";
            }

        }
    }

    public void UpgradeSpeed3()
    {
        if (goldmanager.goldAmount >= speedprice3)
        {
            goldmanager.goldAmount -= speedprice3;
            miner3.miningspeed3--;
            speedprice3 *= 2;
            cps_text3.text = cps3.ToString() + "/s";
            cps3++;
            cps_text3.text = cps3.ToString() + "/s";

            // Save the updated values
            PlayerPrefs.SetInt("speed3", miner3.miningspeed3);
            PlayerPrefs.SetInt("speedprice3", speedprice3);
            PlayerPrefs.SetInt("cps3", cps3);
            PlayerPrefs.Save();

            if (miner3.miningspeed3 <= 0)
            {
                speedprice3text.text = "Max";
            }
        }
    }

    public void UpgradePower1()
    {
        if (goldmanager.goldAmount >= powerprice1)
        {
            goldmanager.goldAmount -= powerprice1;
            miner1.miningpower1++;
            powerprice1 *= 2;
            powerprice1text.text = powerprice1.ToString();
            cps1++;
            cps_text1.text = cps1.ToString() + "/s";
            PlayerPrefs.SetInt("power1", miner1.miningpower1);
            PlayerPrefs.SetInt("powerprice1", powerprice1);
            PlayerPrefs.SetInt("cps1", cps1);
            PlayerPrefs.Save();

            if (miner1.miningpower1 >=10 )
            {
                powerprice1text.text = "Max";
            }

        }
    }

    public void UpgradePower2()
    {
        if (goldmanager.goldAmount >= powerprice2)
        {
            goldmanager.goldAmount -= powerprice2;
            miner2.miningpower2++;
            powerprice2 *= 2;
            powerprice2text.text = powerprice2.ToString();
            cps2++;
            cps_text2.text = cps2.ToString() + "/s";
            PlayerPrefs.SetInt("power2", miner2.miningpower2);
            PlayerPrefs.SetInt("powerprice2", powerprice2);
            PlayerPrefs.SetInt("cps2", cps2);
            PlayerPrefs.Save();

            if (miner2.miningpower2 >= 15)
            {
                powerprice2text.text = "Max";
            }

        }
    }


    public void UpgradePower3()
    {
        if (goldmanager.goldAmount >= powerprice3)
        {
            goldmanager.goldAmount -= powerprice3;
            miner3.miningpower3++;
            powerprice3 *= 2;
            powerprice3text.text = powerprice3.ToString();
            cps3++;
            cps_text3.text = cps3.ToString() + "/s";
            PlayerPrefs.SetInt("power3", miner3.miningpower3);
            PlayerPrefs.SetInt("powerprice3", powerprice3);
            PlayerPrefs.SetInt("cps3", cps3);
            PlayerPrefs.Save();

            if (miner3.miningpower3 <= 25)
            {
                powerprice3text.text = "Max";
            }

        }
    }



    private void OnDestroy()
    {
        PlayerPrefs.SetInt("speed1", miner1.miningspeed1);
        PlayerPrefs.SetInt("speedprice1", speedprice1);
        PlayerPrefs.SetInt("cps1", cps1);

        PlayerPrefs.SetInt("speed2", miner2.miningspeed2);
        PlayerPrefs.SetInt("speedprice2", speedprice2);
        PlayerPrefs.SetInt("cps2", cps2);

        PlayerPrefs.SetInt("speed3", miner3.miningspeed3);
        PlayerPrefs.SetInt("speedprice3", speedprice3);
        PlayerPrefs.SetInt("cps3", cps3);

        PlayerPrefs.SetInt("power1", miner1.miningpower1);
        PlayerPrefs.SetInt("power2", miner2.miningpower2);
        PlayerPrefs.SetInt("power3", miner3.miningpower3);

        PlayerPrefs.SetInt("powerprice1", powerprice1);
        PlayerPrefs.SetInt("powerprice2", powerprice2);
        PlayerPrefs.SetInt("powerprice3", powerprice3);
        //PlayerPrefs.DeleteAll();

    }



}
