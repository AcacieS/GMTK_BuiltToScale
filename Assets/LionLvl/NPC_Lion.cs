
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Lion : MonoBehaviour
{
    public GameObject NPC_dialogue;
    public Animator anim;
    public Text dialogueText;
    public string[] dialogue;
    public AudioClip[] dialogueSound;
    private int index = 0;
    public float wordSpeed;
    public bool playTuto = false;
    private bool continueE = false;
    private bool isWaiting = false;
    private bool isDying = false;

    void Start()
    {
        if (globalScript.tutoActive == false)
        {
            StartCoroutine(Typing());
            SoundManagerScript.instance.PlaySound(dialogueSound[index]);
        }
    }
    // Update is called once per frame
    void Update()
    {


        if (globalScript.tutoActive == false)
        {
            if (NPC_dialogue.activeInHierarchy == true)
            {
                if (anim.GetBool("isDead") == true)
                {
                    if(!isDying){
                        index = 8;
                        dialogueText.text = "";
                        SoundManagerScript.instance.PlaySound(dialogueSound[index]);
                        StartCoroutine(Typing());
                        isDying=true;
                    }
                    globalScript.tutoActive=true;
                }
                else
                {
                    if (index < 4)
                    {
                        if (Input.GetKeyDown(KeyCode.E) && continueE == true)
                        {
                            if (dialogueText.text == dialogue[index])
                            {
                                NextLine();
                            }
                            else
                            {
                                StartCoroutine(Typing());
                            }
                        }
                    }
                    else
                    {
                        if (!isWaiting)
                        {
                            StartCoroutine(WaitDie());
                            isWaiting = true;
                        }
                    }
                }

            }
        }
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if (dialogueText.text == dialogue[index])
        {
            continueE = true;
        }
    }
    public void NextLine()
    {
        continueE = false;
        if (index < dialogue.Length - 2)
        {
            index++;
            dialogueText.text = "";
            SoundManagerScript.instance.PlaySound(dialogueSound[index]);
            StartCoroutine(Typing());
        }
        else
        {
            Debug.Log("index" + index);
            NPC_dialogue.SetActive(false);
            globalScript.tutoActive = true;
            continueE = false;
            zeroText();
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
    }
    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(5);
        NextLine();
        isWaiting = false;
    }

}
