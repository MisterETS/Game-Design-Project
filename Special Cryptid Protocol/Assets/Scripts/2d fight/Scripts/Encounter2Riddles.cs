using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

using Unity.VisualScripting;

public class Encounter2Riddles : MonoBehaviour
{
    public Button Talk;  //correct one

    public TMP_Text Dialoguetext;
    public GameObject Panel;


    public void TalkButton()
    {
        StartCoroutine(PressedButton1());
    }

    public void FinalAnsButton()
    {
        StartCoroutine(PressedButton2());
    }


    IEnumerator PressedButton1()
    {
        Talk.interactable = false;
        Dialoguetext.text = "Welcome , in order to pass , you need to answer my riddles, get one wrong and you will be long gone!";
        yield return new WaitForSeconds(5f);
        Dialoguetext.text = "Your first riddle is 'WHAT DEAR BOY, IS FOOLISH AND RUDE, AND IF IT DOESN'T RUN SHALL BE FOOD?' "; //add here 
        Panel.SetActive(true);
    }

    IEnumerator PressedButton2()
    {
        Dialoguetext.text = "Why , you answered all my riddles, im quite impressed, ill return to my cell , and i hope to see you again after this whole mess is over";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Scene9Encounter3ContainmentRoom");
    }







}
