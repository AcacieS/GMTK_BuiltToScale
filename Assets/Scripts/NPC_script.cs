
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_script : MonoBehaviour
{
    public GameObject NPC_dialogue;
    public Text dialogueText;
    public string[] dialogue;
    public AudioClip[] dialogueSound;
    private int index;
    public float wordSpeed;
    public bool playTuto = false;
    private bool continueE = false;
    void Start(){
        if(globalScript.tutoActive==false){
            StartCoroutine(Typing());
            SoundManagerScript.instance.PlaySound(dialogueSound[index]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(globalScript.tutoActive==false){
            if(NPC_dialogue.activeInHierarchy == true){
                if(Input.GetKeyDown(KeyCode.E)&&continueE==true){
                        if(dialogueText.text == dialogue[index]){
                            NextLine();
                        }else{
                            StartCoroutine(Typing());
                        }
                }
            }
        }
    }
    IEnumerator Typing(){
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if(dialogueText.text == dialogue[index]){
            continueE = true;
        }
    }
    public void NextLine(){
        continueE = false;
        if(index<dialogue.Length-1){
            index++;
            dialogueText.text="";
            SoundManagerScript.instance.PlaySound(dialogueSound[index]);
            StartCoroutine(Typing());
       }else{
            NPC_dialogue.SetActive(false);
            globalScript.tutoActive = true;
            continueE=false;
            zeroText();
        }
    }
    public void zeroText(){
        dialogueText.text = "";
        index=0;
    }
   
}
