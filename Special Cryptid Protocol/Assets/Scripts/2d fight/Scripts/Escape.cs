using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.EventSystems;

using Unity.VisualScripting;

public class Escape : MonoBehaviour
{
    public Button buttonEsc;
    public TMP_Text dialogueText; 


    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
    }

    public void  EscapeVent()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter1[2] == true)
        {
            dialogueText.text = "I can get through here and escape that thing!";
            StartCoroutine(wait());
            SceneManager.LoadScene("Scene5Encounter2");


        }
        else
        {
            dialogueText.text = "I need something to get these screws off the vent.";
        }
    }


    public void HermaticDoor()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter2[2] == true)
        {
            dialogueText.text = "I can get through here and escape that thing!";
            StartCoroutine(wait());
            SceneManager.LoadScene("Scene9Encounter3ContainmentRoom");


        }
        else
        {
            dialogueText.text = "I need a keycard to open this door.";
        }
    }


    public void ElevatorDoor()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter3[2] == true)
        {
            dialogueText.text = "I can get through here and escape that thing!";
            StartCoroutine(wait());
            SceneManager.LoadScene("EscapeEnding");


        }
        else
        {
            dialogueText.text = "There is no power, now way am i getting out of here till its on.";
        }
    }


    public void ScrewDriver()
    {
        MainMenuController.Instance.ListOfItemsEncounter1[2] = true;
        dialogueText.text = "I could use this to get through that vent!";
        buttonEsc.interactable = false;
    }

    public void KeyCard()
    {
        MainMenuController.Instance.ListOfItemsEncounter2[2] = true;
        dialogueText.text = "I could use the keycard to get through that door!";
        buttonEsc.interactable = false;
    }

    public void Power()
    {
        MainMenuController.Instance.ListOfItemsEncounter3[2] = true;
        dialogueText.text = "The power is on, finally i can get out of here!";
        buttonEsc.interactable = false;
    }



}
