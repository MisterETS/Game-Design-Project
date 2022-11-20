using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class PeacefulEncounter1Path : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Button GlassesButton;
    public Button PageOfAnsButton;
    public Button CryoFreezeButt;
   

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
    }

    public void GlassesItem()
    {
        dialogueText.text = "It appears that after going through some of the documents lying on the desk in the corner of the room next to the cell, a speacial pair of glasses is used to peacefully converse with the ape entity, perhaps you can use it to talk with the entity you saw earlier.";
        MainMenuController.Instance.ListOfItemsEncounter1[1] = true;
        //Must have code that shows item was picked up
        GlassesButton.interactable = false;
    }

    public void AnswerPageItem()
    {
        dialogueText.text = "It appears that after going through some of the documents lying on the desk in the corner of the room, some documents talk about a feline creature that likes to ask riddles but punish them for getting them wrong, a side note says that it asks really out of this world riddles so here are the answers to the ones it likes to ask"; 
        MainMenuController.Instance.ListOfItemsEncounter2[1] = true;
        //Must have code that shows item was picked up
        PageOfAnsButton.interactable = false;
    }

    public void CryoFreeze()
    {
        dialogueText.text = "It appears that after going through some of the documents lying on the desk , THis device is capable of putting any organic material in Absolute zero status, but can also revive the organic materilal, perhaps i can use it to freeze that creature? All i need is to get the power on and come back here";
        MainMenuController.Instance.ListOfItemsEncounter3[1] = true;
        //Must have code that shows item was picked up
        CryoFreezeButt.interactable = false;
    }

    public void LeaveScene()
    {
        SceneManager.LoadScene("Scene1Encounter1");
    }

}
