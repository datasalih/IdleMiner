using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BaseMiner5 : MonoBehaviour
{
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private float moveSpeed;
    public Animator anim;
    public UnlockManager unlockmanager;
    public GoldManager goldmanager;
    public int miningspeed5 = 5; // Renamed miningspeed4 to miningspeed5
    public int miningpower5 = 65; // Renamed miningpower4 to miningpower5

    public bool collecting5; // Renamed collecting4 to collecting5

    GameObject coinSound;

    GameObject shaftbutton5; // Renamed shaftbutton4 to shaftbutton5

    private void Start()
    {
        anim = GetComponent<Animator>();
        coinSound = GameObject.Find("CoinSound");
        shaftbutton5 = GameObject.FindGameObjectWithTag("Shaft5"); // Renamed Shaft4 to Shaft5
        miningspeed5 = PlayerPrefs.GetInt("speed5", miningspeed5);
        miningpower5 = PlayerPrefs.GetInt("power5", miningpower5);
    }

    private void Update()
    {
        if (collecting5)
        {
            shaftbutton5.GetComponent<Button>().interactable = false;
        }
    }

    public void MoveMiner5()
    {
        // Disable the button during the animation sequence
        collecting5 = true;
        anim.SetBool("Walking", true);
        anim.SetBool("Idle", false);

        // Move to mining position with ease
        transform.DOMoveX(miningLocation.position.x, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Mining", true);

            // Delay for 5 seconds for mining animation
            DOVirtual.DelayedCall(miningspeed5, () =>
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
                        DOVirtual.DelayedCall(miningspeed5, () =>
                        {
                            anim.SetBool("Walking", true);
                            anim.SetBool("Idle", false);

                            // Rotate back to the initial rotation with ease
                            transform.DORotate(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                anim.SetBool("Walking", false);
                                anim.SetBool("Idle", true);
                                coinSound.GetComponent<AudioSource>().Play();
                                goldmanager.goldAmount += miningpower5;
                                PlayerPrefs.SetInt("gold", goldmanager.goldAmount);
                                PlayerPrefs.Save(); // Update the same goldAmount variable
                                collecting5 = false;

                                // Enable the button after the animation sequence is complete
                                shaftbutton5.GetComponent<Button>().interactable = true;

                                // If automining5 is true, start the next sequence
                                if (unlockmanager.autounlocked5)
                                {
                                    MoveMiner5();
                                }
                            });
                        });
                    });
                });
            });
        });
    }


}
