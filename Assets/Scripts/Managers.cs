using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Managers : MonoBehaviour
{

    public UnlockManager unlockmanager;
    public TMP_Text hiremantext1;
    public TMP_Text hiremantext2;
    public TMP_Text hiremantext3;
    public BaseMiner1 miner1;
    public BaseMiner2 miner2;   
    public BaseMiner3 miner3;

    public TMP_Text speed1text;
    public TMP_Text speed2text;
    public TMP_Text speed3text;
    
    public TMP_Text power1text;
    public TMP_Text power2text;
    public TMP_Text power3text;

  

    private void Update()
    {
        if(miner1.miningspeed1 <= 0)
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

        if (miner1.miningpower1 >= 10)
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

        if (miner2.miningpower2 >= 15)
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


        if (miner3.miningpower3 >= 25)
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


        speed1text.text = "Speed = " + miner1.miningspeed1.ToString()+ " s";
        speed2text.text = "Speed = " + miner2.miningspeed2.ToString()+" s";
        speed3text.text = "Speed = " + miner3.miningspeed3.ToString()+" s";
        
        power1text.text = "Power = " + miner1.miningpower1.ToString();
        power2text.text = "Power = " + miner2.miningpower2.ToString();
        power3text.text = "Power = " + miner3.miningpower3.ToString();
         
    }


    public void OpenManager1()
    {



        transform.GetChild(0).gameObject.SetActive(true);

        if(unlockmanager.autounlocked1)
        {
            hiremantext1.text = "Hired";
        }



        Transform firstChild = transform.GetChild(0);

        // Check if the first child has at least 5 children
        if (firstChild.childCount > 5)
        {
            Transform fifthChild = firstChild.GetChild(4);
            Transform sixthChild = firstChild.GetChild(5);

            if (unlockmanager.autounlocked1)
            {
                fifthChild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);

            }
        }

       


    }

    public void CloseManager1()
    {
        transform.GetChild(0).gameObject.SetActive(false);

    }

    public void OpenManager2()
    {
        transform.GetChild(1).gameObject.SetActive(true);

        if (unlockmanager.autounlocked2)
        {
            hiremantext2.text = "Hired";

        }

        Transform secondChild = transform.GetChild(1);

        if(secondChild.childCount > 5)
        {
            Transform fifthchild = secondChild.GetChild(4);
            Transform sixthChild = secondChild.GetChild(5);

            if (unlockmanager.autounlocked2)
            {
                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);

            }
        }
    }

    public void CloseManager2()
    {
        transform.GetChild(1).gameObject.SetActive(false);

    }

    public void OpenManager3()
    {
        transform.GetChild(2).gameObject.SetActive(true);

        if (unlockmanager.autounlocked3)
        {
            hiremantext3.text = "Hired";

        }


        Transform thirdchild = transform.GetChild(2);

        if(thirdchild.childCount > 5)
        {
            Transform fifthchild = thirdchild.GetChild(4);
            Transform sixthChild = thirdchild.GetChild(5);


            if (unlockmanager.autounlocked3)
            {
                fifthchild.gameObject.SetActive(true);
                sixthChild.gameObject.SetActive(true);

            }

        }
    }

    public void CloseManager3()
    {
        transform.GetChild(2).gameObject.SetActive(false);

    }


    private void OnDestroy()
    {
       // PlayerPrefs.DeleteAll();

    }




}
