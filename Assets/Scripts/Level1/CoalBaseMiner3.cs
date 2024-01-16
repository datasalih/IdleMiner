using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CoalBaseMiner3 : MonoBehaviour
{
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private float moveSpeed;
    public Animator anim;
    public CoalUnlockManager unlockmanager;
    public CoalGoldManager goldmanager;
    public int miningspeed3 = 5;
    public int miningpower3 = 5;


 
    public bool collecting3;





    GameObject coinSound;
  
    GameObject shaftbutton3;



    private void Start()
    {


        anim = GetComponent<Animator>();
        coinSound = GameObject.Find("CoinSound");
        shaftbutton3 = GameObject.FindGameObjectWithTag("Shaft3");
        miningspeed3 = PlayerPrefs.GetInt("speed3", miningspeed3);
        miningpower3 = PlayerPrefs.GetInt("power3", miningpower3);







    }


    private void Update()
    {

  
        if (collecting3)
        {
            shaftbutton3.GetComponent<Button>().interactable = false;

        }

    }



    public void MoveMiner3()
    {
        // Disable the button during the animation sequence
        // You need to define shaftbutton3 or adjust according to your needs


        collecting3 = true;
        anim.SetBool("Walking", true);
        anim.SetBool("Idle", false);

        // Move to mining position with ease
        transform.DOMoveX(miningLocation.position.x, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Mining", true);

            // Delay for 5 seconds for mining animation
            DOVirtual.DelayedCall(miningspeed3, () =>
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
                        DOVirtual.DelayedCall(miningspeed3, () =>
                        {
                            anim.SetBool("Walking", true);
                            anim.SetBool("Idle", false);

                            // Rotate back to the initial rotation with ease
                            transform.DORotate(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                anim.SetBool("Walking", false);
                                anim.SetBool("Idle", true);
                                coinSound.GetComponent<AudioSource>().Play();
                                goldmanager.goldAmount += miningpower3;
                                PlayerPrefs.SetInt("gold", goldmanager.goldAmount);
                                PlayerPrefs.Save(); // Update the same goldAmount variable
                                collecting3 = false;

                                // Enable the button after the animation sequence is complete
                                shaftbutton3.GetComponent<Button>().interactable = true;

                                // If automining3 is true, start the next sequence
                                if (unlockmanager.autounlocked3)
                                {
                                    MoveMiner3();
                                }
                            });
                        });
                    });
                });
            });
        });
    }




}
