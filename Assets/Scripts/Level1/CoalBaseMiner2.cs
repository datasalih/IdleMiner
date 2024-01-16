using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CoalBaseMiner2 : MonoBehaviour
{
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private float moveSpeed;
    public Animator anim;
    public CoalUnlockManager unlockmanager;
    public CoalGoldManager goldmanager;
    public int miningspeed2 = 5;
    public int miningpower2 = 3;



    // public bool collecting1
    public bool collecting2;
   // public bool collecting3;





    GameObject coinSound;
   // public static int goldAmount = 0; // Make goldAmount static
   // public TMP_Text coinText;


  //  GameObject shaftbutton1;
    GameObject shaftbutton2;
   // GameObject shaftbutton3;



    private void Start()
    {

     //   goldAmount = PlayerPrefs.GetInt("gold", goldAmount);

        anim = GetComponent<Animator>();
        coinSound = GameObject.Find("CoinSound");
    //    shaftbutton1 = GameObject.FindGameObjectWithTag("Shaft1");
        shaftbutton2 = GameObject.FindGameObjectWithTag("Shaft2");
        //   shaftbutton3 = GameObject.FindGameObjectWithTag("Shaft3");
        miningspeed2 = PlayerPrefs.GetInt("speed2", miningspeed2);
        miningpower2 = PlayerPrefs.GetInt("power2", miningpower2);



        /*if (unlockmanager.autounlocked1)
        {
            Invoke("MoveMiner1", 1f);
        }

        else if (unlockmanager.autounlocked2)
        {
            Invoke("MoveMiner2", 1f);
        }
        else if (unlockmanager.autounlocked3)
        {
            Invoke("MoveMiner3", 1f);
            
        }*/



    }


    private void Update()
    {

       // coinText.text = goldAmount.ToString();

     /*   if(collecting1)
        {
            shaftbutton1.GetComponent<Button>().interactable = false;

        }*/
        if(collecting2)
        {
            shaftbutton2.GetComponent<Button>().interactable = false;

        }

      /*  if (collecting3)
       {
            shaftbutton3.GetComponent<Button>().interactable = false;

        } */

    }

 

    public void MoveMiner2()
    {

        collecting2 = true;
        anim.SetBool("Walking", true);
        anim.SetBool("Idle", false);

        // Move to mining position with ease
        transform.DOMoveX(miningLocation.position.x, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Mining", true);

            // Delay for 5 seconds for mining animation
            DOVirtual.DelayedCall(miningspeed2, () =>
            {
                anim.SetBool("Mining", false);

                // Rotate to the opposite position with ease
                transform.DORotate(new Vector3(0, 180, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    anim.SetBool("Walking", true);

                    // Move back to the deposit location with ease
                    transform.DOMoveX(depositLocation.position.x, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        anim.SetBool("Walking", false);
                        anim.SetBool("Idle", true);

                        // Delay for 5 seconds at the deposit location
                        DOVirtual.DelayedCall(miningspeed2, () =>
                        {
                            anim.SetBool("Walking", true);
                            anim.SetBool("Idle", false);

                            // Rotate back to the initial rotation with ease
                            transform.DORotate(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                anim.SetBool("Walking", false);
                                anim.SetBool("Idle", true);
                                coinSound.GetComponent<AudioSource>().Play();
                                goldmanager.goldAmount += miningpower2;  // Update the same goldAmount variable
                                PlayerPrefs.SetInt("gold", goldmanager.goldAmount);
                                PlayerPrefs.Save();
                                collecting2 = false;

                                // Enable the button after the animation sequence is complete
                                shaftbutton2.GetComponent<Button>().interactable = true;

                                // If automining2 is true, start the next sequence
                                if (unlockmanager.autounlocked2)
                                {
                                    MoveMiner2();
                                }
                            });
                        });
                    });
                });
            });
        });
    }

    
    



}
