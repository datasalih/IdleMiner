using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RubyBaseMiner6 : MonoBehaviour
{
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private float moveSpeed;
    public Animator anim;
    public RubyUnlockManager unlockmanager;
    public RubyGoldManager goldmanager;
    public int miningspeed6 = 5;
    public int miningpower6 = 2000;

    public bool collecting6;

    GameObject coinSound;

    GameObject shaftbutton6;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coinSound = GameObject.Find("CoinSound");
        shaftbutton6 = GameObject.FindGameObjectWithTag("Shaft6");
        miningspeed6 = PlayerPrefs.GetInt("speed6", miningspeed6);
        miningpower6 = PlayerPrefs.GetInt("power6", miningpower6);
    }

    private void Update()
    {
        if (collecting6)
        {
            shaftbutton6.GetComponent<Button>().interactable = false;
        }
    }

    public void MoveMiner6()
    {
        // Disable the button during the animation sequence
        // You need to define shaftbutton4 or adjust according to your needs

        collecting6 = true;
        anim.SetBool("Walking", true);
        anim.SetBool("Idle", false);

        // Move to mining position with ease
        transform.DOMoveX(miningLocation.position.x, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Mining", true);

            // Delay for 5 seconds for mining animation
            DOVirtual.DelayedCall(miningspeed6, () =>
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
                        DOVirtual.DelayedCall(miningspeed6, () =>
                        {
                            anim.SetBool("Walking", true);
                            anim.SetBool("Idle", false);

                            // Rotate back to the initial rotation with ease
                            transform.DORotate(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                anim.SetBool("Walking", false);
                                anim.SetBool("Idle", true);
                                coinSound.GetComponent<AudioSource>().Play();
                                goldmanager.goldAmount += miningpower6;
                                PlayerPrefs.SetInt("gold", goldmanager.goldAmount);
                                PlayerPrefs.Save(); // Update the same goldAmount variable
                                collecting6 = false;

                                // Enable the button after the animation sequence is complete
                                shaftbutton6.GetComponent<Button>().interactable = true;

                                // If automining4 is true, start the next sequence
                                if (unlockmanager.autounlocked6)
                                {
                                    MoveMiner6();
                                }
                            });
                        });
                    });
                });
            });
        });
    }


}
