using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;



public class Escape : MonoBehaviour
{
    public Button buttonEsc;
    public Button buttonEscape1;
    public Button buttonEscape2;
    public Button buttonEscape3;
    public TMP_Text dialogueText;

    IEnumerator waitup()
    {

        yield return new WaitForSeconds(5f);
    }
    IEnumerator wait()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(0.5f);
        if(MainMenuController.Instance.ListOfItemsEncounter1[2] == true && scene.name == "Scene1Encounter1")
        {
            dialogueText.text = "I feel bad about leaving without dealing with the creatures, but I need to look out for myself first.";
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Scene4.5Encounter2Hall");
        }

        if (MainMenuController.Instance.ListOfItemsEncounter2[2] == true && scene.name == "Scene4.5Encounter2Hall")
        {
            dialogueText.text = "You head through a secret entrance in the Janitors closet, escape is moments away. This mess is someone elses problem.";
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Scene9Encounter3ContainmentRoom");
        }

        if(MainMenuController.Instance.EscapeRoute[2] == true && scene.name == "Scene11MainHall")
        {
            SceneManager.LoadScene("EscapeEnding");
        }
    }

    public void  EscapeVent()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter1[2] == true)
        {
            MainMenuController.Instance.EscapeRoute[0] = true;
            StartCoroutine(wait());
           


        }
        else
        {
            dialogueText.text = "I can escape from here without dealing with the subject, I just need a screwdriver for the bolts. Dunno if it's right to just leave without dealing with the problem.";
        }
    }


    public void HermaticDoor()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter2[2] == true)
        {
            dialogueText.text = "I feel bad about leaving without dealing with the creatures, but I need to look out for myself first.";
            StartCoroutine(waitup());
            MainMenuController.Instance.EscapeRoute[1] = true;
            StartCoroutine(wait());
            


        }
        else
        {
            dialogueText.text = "I need a keycard to open this door, the cleanup crew can deal with this after im out.";
        }
    }


    public void ElevatorDoor()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter3[2] == true)
        {
            dialogueText.text = "You head through a secret entrance in the Janitors closet, escape is moments away. This mess is someone elses problem.";
            StartCoroutine(waitup());
            MainMenuController.Instance.EscapeRoute[2] = true;
            StartCoroutine(wait());
            


        }
        else
        {
            dialogueText.text = "There is no power, now way am i getting out of here till its on.";
        }
    }


    public void ScrewDriver()
    {
        MainMenuController.Instance.ListOfItemsEncounter1[2] = true;
        dialogueText.text = "Look like this has a screwdriver, should come in handy.";
        buttonEscape1.interactable = false;
        buttonEscape1.GetComponent<Image>().enabled = false;
    }

    public void KeyCard()
    {
        MainMenuController.Instance.ListOfItemsEncounter2[2] = true;
        dialogueText.text = "The janitors keycard, this must have been the last place he was cleaning before he went missing.";
        buttonEsc.interactable = false;
        buttonEscape1.GetComponent<Image>().enabled = false;
    }

    public void Power()
    {
        MainMenuController.Instance.ListOfItemsEncounter3[2] = true;
        dialogueText.text = "The power is on, finally i can get out of here!";
        buttonEscape1.interactable = false;
        buttonEscape1.GetComponent<Image>().enabled = false;
    }

    private void Start()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter1[2] == true)
        {
            buttonEscape1.interactable = false;
            buttonEscape1.GetComponent<Image>().enabled = false;
        }

        if (MainMenuController.Instance.ListOfItemsEncounter2[2] == true)
        {
            buttonEscape2.interactable = false;
            buttonEscape1.GetComponent<Image>().enabled = false;
        }

         if (MainMenuController.Instance.ListOfItemsEncounter3[2] == true )
         {
            buttonEscape3.interactable = false;
            buttonEscape1.GetComponent<Image>().enabled = false;
        }
    }

}
