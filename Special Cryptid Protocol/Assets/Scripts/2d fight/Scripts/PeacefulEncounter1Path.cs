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

    public void LeaveScene()
    {
        SceneManager.LoadScene("Scene1Encounter1");
    }
}
