using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoalUnlockManager : MonoBehaviour
{
    public CoalBaseMiner1 miner1;
    public CoalBaseMiner2 miner2;
    public CoalBaseMiner3 miner3;
    public CoalBaseMiner4 miner4;
    public CoalBaseMiner5 miner5; // Added BaseMiner5
    public CoalBaseMiner6 miner6; // Added BaseMiner6

    public CoalGoldManager goldmanager;
    public CoalManagers manager;

    int shaft2Price = 5;
    int shaft3Price = 15;
    int shaft4Price = 30;
    int shaft5Price = 100; // Added shaft5Price
    int shaft6Price = 250; // Added shaft6Price

    int autominingprice1 = 10;
    int autominingprice2 = 25;
    int autominingprice3 = 60;
    int autominingprice4 = 125;
    int autominingprice5 = 250; // Added autominingprice5
    int autominingprice6 = 500; // Added autominingprice6

    int speedprice1 = 4;
    int speedprice2 = 8;
    int speedprice3 = 12;
    int speedprice4 = 16;
    int speedprice5 = 20; // Added speedprice5
    int speedprice6 = 25; // Added speedprice6

    int powerprice1 = 4;
    int powerprice2 = 8;
    int powerprice3 = 12;
    int powerprice4 = 16;
    int powerprice5 = 20; // Added powerprice5
    int powerprice6 = 25; // Added powerprice6

    int cps1 = 1;
    int cps2 = 3;
    int cps3 = 5;
    int cps4 = 10;
    int cps5 = 25; // Added cps5
    int cps6 = 50; // Added cps6

    public bool shaft2Unlocked;
    public bool shaft3Unlocked;
    public bool shaft4Unlocked;
    public bool shaft5Unlocked; // Added shaft5Unlocked
    public bool shaft6Unlocked; // Added shaft6Unlocked

    public bool autounlocked1;
    public bool autounlocked2;
    public bool autounlocked3;
    public bool autounlocked4;
    public bool autounlocked5; // Added autounlocked5
    public bool autounlocked6; // Added autounlocked6

    GameObject Unlockables;
    GameObject UnlockButtons;

    public Button manager1btn;
    public Button manager2btn;
    public Button manager3btn;
    public Button manager4btn;
    public Button manager5btn; // Added manager5btn
    public Button manager6btn; // Added manager6btn

    public TMP_Text speedprice1text;
    public TMP_Text speedprice2text;
    public TMP_Text speedprice3text;
    public TMP_Text speedprice4text;
    public TMP_Text speedprice5text; // Added speedprice5text
    public TMP_Text speedprice6text; // Added speedprice6text

    public TMP_Text powerprice1text;
    public TMP_Text powerprice2text;
    public TMP_Text powerprice3text;
    public TMP_Text powerprice4text;
    public TMP_Text powerprice5text; // Added powerprice5text
    public TMP_Text powerprice6text; // Added powerprice6text

    public TMP_Text cps_text1;
    public TMP_Text cps_text2;
    public TMP_Text cps_text3;
    public TMP_Text cps_text4;
    public TMP_Text cps_text5; // Added cps_text5
    public TMP_Text cps_text6; // Added cps_text6

    private void Start()
    {
        Unlockables = GameObject.FindGameObjectWithTag("Unlockables");
        UnlockButtons = GameObject.FindGameObjectWithTag("UnlockButtons");

        shaft2Unlocked = PlayerPrefs.GetInt("shaft2", 0) == 1;
        shaft3Unlocked = PlayerPrefs.GetInt("shaft3", 0) == 1;
        shaft4Unlocked = PlayerPrefs.GetInt("shaft4", 0) == 1;
        shaft5Unlocked = PlayerPrefs.GetInt("shaft5", 0) == 1;
        shaft6Unlocked = PlayerPrefs.GetInt("shaft6", 0) == 1;

        autounlocked1 = PlayerPrefs.GetInt("auto1", 0) == 1;
        autounlocked2 = PlayerPrefs.GetInt("auto2", 0) == 1;
        autounlocked3 = PlayerPrefs.GetInt("auto3", 0) == 1;
        autounlocked4 = PlayerPrefs.GetInt("auto4", 0) == 1; // Added autounlocked4
        autounlocked5 = PlayerPrefs.GetInt("auto5", 0) == 1;
        autounlocked6 = PlayerPrefs.GetInt("auto6", 0) == 1;


        speedprice1 = PlayerPrefs.GetInt("speedprice1", speedprice1);
        speedprice2 = PlayerPrefs.GetInt("speedprice2", speedprice2);
        speedprice3 = PlayerPrefs.GetInt("speedprice3", speedprice3);
        speedprice4 = PlayerPrefs.GetInt("speedprice4", speedprice4); // Added speedprice4
        speedprice5 = PlayerPrefs.GetInt("speedprice5", speedprice5);
        speedprice6 = PlayerPrefs.GetInt("speedprice6", speedprice6);

        powerprice1 = PlayerPrefs.GetInt("powerprice1", powerprice1);
        powerprice2 = PlayerPrefs.GetInt("powerprice2", powerprice2);
        powerprice3 = PlayerPrefs.GetInt("powerprice3", powerprice3);
        powerprice4 = PlayerPrefs.GetInt("powerprice4", powerprice4); // Added powerprice4
        powerprice5 = PlayerPrefs.GetInt("powerprice5", powerprice5);
        powerprice6 = PlayerPrefs.GetInt("powerprice6", powerprice6);

        cps1 = PlayerPrefs.GetInt("cps1", cps1);
        cps2 = PlayerPrefs.GetInt("cps2", cps2);
        cps3 = PlayerPrefs.GetInt("cps3", cps3);
        cps4 = PlayerPrefs.GetInt("cps4", cps4); // Added cps4
        cps5 = PlayerPrefs.GetInt("cps5", cps5);
        cps6 = PlayerPrefs.GetInt("cps6", cps6);

        if (shaft2Unlocked)
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

        if (shaft3Unlocked)
        {
            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        if (shaft4Unlocked) // Added condition for shaft4
        {
            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (shaft5Unlocked)
        {
            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(false); // Assuming the index is 3 for shaft 5
                UnlockButtons.transform.GetChild(4).gameObject.SetActive(true); // Assuming the index is 4 for shaft 6
            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(4).gameObject.SetActive(true); // Assuming the index is 4 for shaft 5
            }
        }

        if (shaft6Unlocked)
        {
            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(4).gameObject.SetActive(false); // Assuming the index is 4 for shaft 6
              //  UnlockButtons.transform.GetChild(5).gameObject.SetActive(true); // Adjust the index based on your actual implementation
            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(5).gameObject.SetActive(true); // Adjust the index based on your actual implementation
            }
        }


        if (autounlocked1)
        {
            manager1btn.interactable = false;
            miner1.MoveMiner1();

        }

        if (autounlocked2)
        {
            manager2btn.interactable = false;
            miner2.MoveMiner2();
        }

        if (autounlocked3)
        {
            manager3btn.interactable = false;
            miner3.MoveMiner3();
        }

        if (autounlocked4) // Added condition for autounlocked4
        {
            manager4btn.interactable = false;
            miner4.MoveMiner4();
        }

        if (autounlocked5) // Added condition for autounlocked4
        {
            manager5btn.interactable = false;
            miner5.MoveMiner5();
        }

        if (autounlocked6) // Added condition for autounlocked4
        {
            manager6btn.interactable = false;
            miner6.MoveMiner6();
        }
    }


    private void Update()
    {

        powerprice1text.text = powerprice1.ToString();
        powerprice2text.text = powerprice2.ToString();
        powerprice3text.text = powerprice3.ToString();
        powerprice4text.text = powerprice4.ToString();
        powerprice5text.text = powerprice5.ToString();
        powerprice6text.text = powerprice6.ToString();

        speedprice1text.text = speedprice1.ToString();
        speedprice2text.text = speedprice2.ToString();
        speedprice3text.text = speedprice3.ToString();
        speedprice4text.text = speedprice4.ToString(); 
        speedprice5text.text = speedprice5.ToString();
        speedprice6text.text = speedprice6.ToString();

        cps_text1.text = cps1.ToString() + "/s";
        cps_text2.text = cps2.ToString() + "/s";
        cps_text3.text = cps3.ToString() + "/s";
        cps_text4.text = cps4.ToString() + "/s";
        cps_text5.text = cps5.ToString() + "/s";
        cps_text6.text = cps6.ToString() + "/s";





        if (miner1.miningspeed1 <= 0)
        {
            speedprice1text.text = "Max";
        }


        if (miner2.miningspeed2 <= 0)
        {
            speedprice2text.text = "Max";
        }


        if (miner3.miningspeed3 <= 0)
        {
            speedprice3text.text = "Max";
        }


        if (miner4.miningspeed4 <= 0) // Added for miner4
        {
            speedprice4text.text = "Max";
        }

        if(miner5.miningspeed5 <=0)
        {
            speedprice5text.text = "Max";
        }

        if(miner6.miningspeed6 <= 0)
        {
            speedprice6text.text = "Max";
        }

 

        if (miner1.miningpower1 >= 6)
        {
            powerprice1text.text = "Max";
        }

        if (miner2.miningpower2 >= 8)
        {
            powerprice2text.text = "Max";
        }

        if (miner3.miningpower3 >= 10)
        {
            powerprice3text.text = "Max";
        }

        if (miner4.miningpower4 >= 15) // Added for miner4
        {
            powerprice4text.text = "Max";
        }

        if (miner5.miningpower5 >= 30) // Added for miner4
        {
            powerprice5text.text = "Max";
        }

        if (miner6.miningpower6 >= 55) // Added for miner4
        {
            powerprice6text.text = "Max";
        }
    }


    public void UnlockShaft2()
    {
        if (goldmanager.goldAmount >= shaft2Price)
        {
            shaft2Unlocked = true;
            goldmanager.goldAmount -= shaft2Price;
            PlayerPrefs.SetInt("coalgold", goldmanager.goldAmount);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("shaft2",1);

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
            PlayerPrefs.SetInt("coalgold", goldmanager.goldAmount);
            PlayerPrefs.SetInt("shaft3", 1);


            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(1).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

    }

    public void UnlockShaft4()
    {
        if (goldmanager.goldAmount >= shaft4Price)
        {
            shaft4Unlocked = true;
            goldmanager.goldAmount -= shaft4Price;
            PlayerPrefs.SetInt("coalgold", goldmanager.goldAmount);
            PlayerPrefs.SetInt("shaft4", 1);


            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(2).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

    }

    public void UnlockShaft5()
    {
        if (goldmanager.goldAmount >= shaft5Price)
        {
            shaft5Unlocked = true;
            goldmanager.goldAmount -= shaft5Price;
            PlayerPrefs.SetInt("coalgold", goldmanager.goldAmount);
            PlayerPrefs.SetInt("shaft5", 1);

            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(3).gameObject.SetActive(false);
                UnlockButtons.transform.GetChild(4).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(4).gameObject.SetActive(true);
            }
        }
    }

    public void UnlockShaft6()
    {
        if (goldmanager.goldAmount >= shaft6Price)
        {
            shaft6Unlocked = true;
            goldmanager.goldAmount -= shaft6Price;
            PlayerPrefs.SetInt("coalgold", goldmanager.goldAmount);
            PlayerPrefs.SetInt("shaft6", 1);

            for (int i = 0; i < UnlockButtons.transform.childCount; i++)
            {
                UnlockButtons.transform.GetChild(4).gameObject.SetActive(false);
               // UnlockButtons.transform.GetChild(5).gameObject.SetActive(true);

            }

            for (int i = 0; i < Unlockables.transform.childCount; i++)
            {
                Unlockables.transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    public void HireManager1()
    {
        if (goldmanager.goldAmount >= autominingprice1)
        {
            autounlocked1 = true;
            goldmanager.goldAmount -= autominingprice1;
            manager.hiremantext1.text = "Hired";
            PlayerPrefs.SetInt("auto1", 1);
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
        if (goldmanager.goldAmount >= autominingprice3)
        {
            autounlocked3 = true;
            goldmanager.goldAmount -= autominingprice3;
            manager.hiremantext3.text = "Hired";
            PlayerPrefs.SetInt("auto3", 1); // Use a different key for manager 3
            PlayerPrefs.Save();
            manager3btn.interactable = false;
            miner3.MoveMiner3();
        }
    }

    public void HireManager4()
    {
        if (goldmanager.goldAmount >= autominingprice4)
        {
            autounlocked4 = true;
            goldmanager.goldAmount -= autominingprice4;
            manager.hiremantext4.text = "Hired";
            PlayerPrefs.SetInt("auto4", 1); // Use a different key for manager 4
            PlayerPrefs.Save();
            manager4btn.interactable = false;
            miner4.MoveMiner4();
        }

    }

    public void HireManager5()
    {
        if (goldmanager.goldAmount >= autominingprice5)
        {
            autounlocked5 = true;
            goldmanager.goldAmount -= autominingprice5;
            manager.hiremantext5.text = "Hired";
            PlayerPrefs.SetInt("auto5", 1); // Use a different key for manager 5
            PlayerPrefs.Save();
            manager5btn.interactable = false;
            miner5.MoveMiner5();
        }
    }

    public void HireManager6()
    {
        if (goldmanager.goldAmount >= autominingprice6)
        {
            autounlocked6 = true;
            goldmanager.goldAmount -= autominingprice6;
            manager.hiremantext6.text = "Hired";
            PlayerPrefs.SetInt("auto6", 1); // Use a different key for manager 6
            PlayerPrefs.Save();
            manager6btn.interactable = false;
            miner6.MoveMiner6();
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

    public void UpgradeSpeed4()
    {
        if (goldmanager.goldAmount >= speedprice4)
        {
            goldmanager.goldAmount -= speedprice4;
            miner4.miningspeed4--;
            speedprice4 *= 2;
            speedprice4text.text = speedprice4.ToString();
            cps4++;
            cps_text4.text = cps4.ToString() + "/s";
            PlayerPrefs.SetInt("speed4", miner4.miningspeed4);
            PlayerPrefs.SetInt("speedprice4", speedprice4);
            PlayerPrefs.SetInt("cps4", cps4);
            PlayerPrefs.Save();

            if (miner4.miningspeed4 <= 0)
            {
                speedprice4text.text = "Max";
            }
        }
    }

    public void UpgradeSpeed5()
    {
        if (goldmanager.goldAmount >= speedprice5)
        {
            goldmanager.goldAmount -= speedprice5;
            miner5.miningspeed5--; // Make sure you have miner5 defined
            speedprice5 *= 2;
            speedprice5text.text = speedprice5.ToString();
            cps5++;
            cps_text5.text = cps5.ToString() + "/s";
            PlayerPrefs.SetInt("speed5", miner5.miningspeed5);
            PlayerPrefs.SetInt("speedprice5", speedprice5);
            PlayerPrefs.SetInt("cps5", cps5);
            PlayerPrefs.Save();

            if (miner5.miningspeed5 <= 0)
            {
                speedprice5text.text = "Max";
            }
        }
    }

    public void UpgradeSpeed6()
    {
        if (goldmanager.goldAmount >= speedprice6)
        {
            goldmanager.goldAmount -= speedprice6;
            miner6.miningspeed6--; // Make sure you have miner6 defined
            speedprice6 *= 2;
            speedprice6text.text = speedprice6.ToString();
            cps6++;
            cps_text6.text = cps6.ToString() + "/s";
            PlayerPrefs.SetInt("speed6", miner6.miningspeed6);
            PlayerPrefs.SetInt("speedprice6", speedprice6);
            PlayerPrefs.SetInt("cps6", cps6);
            PlayerPrefs.Save();

            if (miner6.miningspeed6 <= 0)
            {
                speedprice6text.text = "Max";
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



        }
    }

    public void UpgradePower4()
    {
        if (goldmanager.goldAmount >= powerprice4)
        {
            goldmanager.goldAmount -= powerprice4;
            miner4.miningpower4++;
            powerprice4 *= 2;
            powerprice4text.text = powerprice4.ToString();
            cps4++;
            cps_text4.text = cps4.ToString() + "/s";
            PlayerPrefs.SetInt("power4", miner4.miningpower4);
            PlayerPrefs.SetInt("powerprice4", powerprice4);
            PlayerPrefs.SetInt("cps4", cps4);
            PlayerPrefs.Save();

         
        }
    }

    public void UpgradePower5()
    {
        if (goldmanager.goldAmount >= powerprice5)
        {
            goldmanager.goldAmount -= powerprice5;
            miner5.miningpower5++; // Make sure you have miner5 defined
            powerprice5 *= 2;
            powerprice5text.text = powerprice5.ToString();
            cps5++;
            cps_text5.text = cps5.ToString() + "/s";
            PlayerPrefs.SetInt("power5", miner5.miningpower5);
            PlayerPrefs.SetInt("powerprice5", powerprice5);
            PlayerPrefs.SetInt("cps5", cps5);
            PlayerPrefs.Save();


        }
    }

    public void UpgradePower6()
    {
        if (goldmanager.goldAmount >= powerprice6)
        {
            goldmanager.goldAmount -= powerprice6;
            miner6.miningpower6++; // Make sure you have miner6 defined
            powerprice6 *= 2;
            powerprice6text.text = powerprice6.ToString();
            cps6++;
            cps_text6.text = cps6.ToString() + "/s";
            PlayerPrefs.SetInt("power6", miner6.miningpower6);
            PlayerPrefs.SetInt("powerprice6", powerprice6);
            PlayerPrefs.SetInt("cps6", cps6);
            PlayerPrefs.Save();

         
        }
    }

    private void OnDestroy()
    {
        /*PlayerPrefs.SetInt("speed1", miner1.miningspeed1);
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
        PlayerPrefs.SetInt("powerprice3", powerprice3);*/


    }



}
