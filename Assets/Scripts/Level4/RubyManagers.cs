using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RubyManagers : MonoBehaviour
{
    public RubyUnlockManager unlockmanager;
    public TMP_Text hiremantext1;
    public TMP_Text hiremantext2;
    public TMP_Text hiremantext3;
    public TMP_Text hiremantext4; 
    public TMP_Text hiremantext5; 
    public TMP_Text hiremantext6; 

    public RubyBaseMiner1 miner1;
    public RubyBaseMiner2 miner2;
    public RubyBaseMiner3 miner3;
    public RubyBaseMiner4 miner4;
    public RubyBaseMiner5 miner5; 
    public RubyBaseMiner6 miner6; 

    public TMP_Text speed1text;
    public TMP_Text speed2text;
    public TMP_Text speed3text;
    public TMP_Text speed4text; 
    public TMP_Text speed5text; 
    public TMP_Text speed6text; 

    public TMP_Text power1text;
    public TMP_Text power2text;
    public TMP_Text power3text;
    public TMP_Text power4text; 
    public TMP_Text power5text;
    public TMP_Text power6text; 

    public TMP_Text lvlgoldamounttxt;
    public RubyGoldManager goldmanager;

    private void Update()
    {


        lvlgoldamounttxt.text = goldmanager.goldAmount.ToString();


        if (miner1.miningspeed1 <= 0)
        {
            Transform firstchild = transform.GetChild(0);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;
                }

            }
        }

        if (miner1.miningpower1 >= 100)
        {
            Transform firstchild = transform.GetChild(0);

            if (firstchild.childCount > 5)
            {
                Transform sixthchild = firstchild.GetChild(5);

                {
                    sixthchild.gameObject.GetComponent<Button>().interactable = false;
                }

            }
        }


        if (miner2.miningspeed2 <= 0)
        {
            Transform firstchild = transform.GetChild(1);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;
                }

            }
        }

        if (miner2.miningpower2 >= 150)
        {
            Transform firstchild = transform.GetChild(1);

            if (firstchild.childCount > 5)
            {
                Transform sixthchild = firstchild.GetChild(5);

                {
                    sixthchild.gameObject.GetComponent<Button>().interactable = false;
                }

            }
        }


        if (miner3.miningspeed3 <= 0)
        {
            Transform firstchild = transform.GetChild(2);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;
                }

            }
        }


        if (miner3.miningpower3 >= 250)
        {
            Transform firstchild = transform.GetChild(2);

            if (firstchild.childCount > 5)
            {
                Transform sixthchild = firstchild.GetChild(5);

                {
                    sixthchild.gameObject.GetComponent<Button>().interactable = false;
                }

            }
        }

        if (miner4.miningspeed4 <= 0)
        {
            Transform firstchild = transform.GetChild(3);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }

        if (miner4.miningpower4 >= 550)
        {
            Transform firstchild = transform.GetChild(3);

            if (firstchild.childCount > 5)
            {
                Transform sixthchild = firstchild.GetChild(5);

                {
                    sixthchild.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }

        // Continue for miners 5 and 6
        if (miner5.miningspeed5 <= 0)
        {
            Transform firstchild = transform.GetChild(4);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }

        if (miner5.miningpower5 >= 1050)
        {
            Transform firstchild = transform.GetChild(4);

            if (firstchild.childCount > 5)
            {
                Transform sixthchild = firstchild.GetChild(5);

                {
                    sixthchild.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }

        if (miner6.miningspeed6 <= 0)
        {
            Transform firstchild = transform.GetChild(5);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }

        if (miner6.miningpower6 >= 2050)
        {
            Transform firstchild = transform.GetChild(5);

            if (firstchild.childCount > 5)
            {
                Transform sixthchild = firstchild.GetChild(5);

                {
                    sixthchild.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }


        Transform firstChild = transform.GetChild(0);

        // Check if the first child has at least 5 children
        if (firstChild.childCount > 5)
        {
            Transform fifthhChild = firstChild.GetChild(4);
            Transform sixthChild = firstChild.GetChild(5);

            if (unlockmanager.autounlocked1)
            {
                hiremantext1.text = "Hired";
                fifthhChild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);

            }
        }



        Transform secondChild = transform.GetChild(1);

        if (secondChild.childCount > 5)
        {
            Transform fifthchild = secondChild.GetChild(4);
            Transform sixthChild = secondChild.GetChild(5);

            if (unlockmanager.autounlocked2)
            {
                hiremantext2.text = "Hired";
                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);

            }
        }

        Transform thirdchild = transform.GetChild(2);

        if (thirdchild.childCount > 5)
        {
            Transform fifthchild = thirdchild.GetChild(4);
            Transform sixthChild = thirdchild.GetChild(5);


            if (unlockmanager.autounlocked3)
            {
                hiremantext3.text = "Hired";
                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);

            }

        }


     
        Transform fourthChild = transform.GetChild(3);

        if (fourthChild.childCount > 5)
        {
            Transform fifthchild = fourthChild.GetChild(4);
            Transform sixthChild = fourthChild.GetChild(5);

            if (unlockmanager.autounlocked4)
            {
                hiremantext4.text = "Hired";

                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);
            }
        }


     
        Transform fifthChild = transform.GetChild(4);

        if (fifthChild.childCount > 5)
        {
            Transform fifthchild = fifthChild.GetChild(4);
            Transform sixthChild = fifthChild.GetChild(5);

            if (unlockmanager.autounlocked5)
            {
                hiremantext5.text = "Hired";

                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);
            }
        }

      

        Transform lastchild = transform.GetChild(5);

        if (lastchild.childCount > 5)
        {
            Transform fifthchild = lastchild.GetChild(4);
            Transform sixthChild = lastchild.GetChild(5);

            if (unlockmanager.autounlocked6)
            {
                hiremantext6.text = "Hired";

                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);
            }
        }


        // Update the UI for Manager 1
        UpdateManagerUI(miner1.miningspeed1, miner1.miningpower1, hiremantext1, speed1text, power1text);

        // Update the UI for Manager 2
        UpdateManagerUI(miner2.miningspeed2, miner2.miningpower2, hiremantext2, speed2text, power2text);

        // Update the UI for Manager 3
        UpdateManagerUI(miner3.miningspeed3, miner3.miningpower3, hiremantext3, speed3text, power3text);

        // Update the UI for Manager 4
        UpdateManagerUI(miner4.miningspeed4, miner4.miningpower4, hiremantext4, speed4text, power4text);

        UpdateManagerUI(miner5.miningspeed5, miner5.miningpower5, hiremantext5, speed5text, power5text);

        UpdateManagerUI(miner6.miningspeed6, miner6.miningpower6, hiremantext6, speed6text, power6text);

    }

    private void UpdateManagerUI(int miningSpeed, int miningPower, TMP_Text hiremantext, TMP_Text speedtext, TMP_Text powertext)
    {
        // Update the speed UI
        speedtext.text = "Speed = " + miningSpeed.ToString() + " s";

        // Update the power UI
        powertext.text = "Power = " + miningPower.ToString();

        // Check if mining speed is zero
       /*  if (miningSpeed <= 0)
        {
            Transform firstchild = transform.GetChild(0);

            if (firstchild.childCount > 4)
            {
                Transform fifthchild = firstchild.GetChild(4);
                Transform sixthChild = firstchild.GetChild(5);

                {
                    fifthchild.gameObject.GetComponent<Button>().interactable = false;

                    // If mining power reaches 10, disable the sixth child button
                    if (miningPower >= 10)
                    {
                        sixthChild.gameObject.GetComponent<Button>().interactable = false;
                    }
                }
            }
        }*/
    }

    public void OpenManager1()
    {
        transform.GetChild(0).gameObject.SetActive(true);

      


    }

    public void CloseManager1()
    {
        transform.GetChild(0).gameObject.SetActive(false);

    }

    public void OpenManager2()
    {
        transform.GetChild(1).gameObject.SetActive(true);


    }

    public void CloseManager2()
    {
        transform.GetChild(1).gameObject.SetActive(false);

    }

    public void OpenManager3()
    {
        transform.GetChild(2).gameObject.SetActive(true);

     


       
    }

    public void CloseManager3()
    {
        transform.GetChild(2).gameObject.SetActive(false);

    }

    public void OpenManager4()
    {
        transform.GetChild(3).gameObject.SetActive(true);

       
    }

    public void CloseManager4()
    {
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void OpenManager5()
    {
        transform.GetChild(4).gameObject.SetActive(true);

      
    }

    public void CloseManager5()
    {
        transform.GetChild(4).gameObject.SetActive(false);
    }

    public void OpenManager6()
    {
        transform.GetChild(5).gameObject.SetActive(true);

       
    }

    public void CloseManager6()
    {
        transform.GetChild(5).gameObject.SetActive(false);
    }

    public void OpenLevelPanel()
    {

        Transform openlvlpanel = transform.GetChild(6);

        Transform lvlpanel = openlvlpanel.GetChild(0);

        lvlpanel.gameObject.SetActive(true);

    }

    public void CloseLevelPanel()
    {

        Transform openlvlpanel = transform.GetChild(6);

        Transform lvlpanel = openlvlpanel.GetChild(0);

        lvlpanel.gameObject.SetActive(false);

    }




}
