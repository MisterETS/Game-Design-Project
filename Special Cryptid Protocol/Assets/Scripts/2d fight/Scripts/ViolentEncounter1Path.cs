using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class ViolentEncounter1Path : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Button GunButton;
    public Button HighSonicDeviceButton;
    public Button IncedinaryDevice;

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
    }

    public void GunItem()
    {
        dialogueText.text = "It appears that in the armory a gun was left behind in the panic, perhaps you can make use of it.";
        MainMenuController.Instance.ListOfItemsEncounter1[0] = true;
        //Must have code that shows item was picked up
        GunButton.interactable = false;
    }

    public void LeaveScene()
    {
        SceneManager.LoadScene("Scene1Encounter1");
    }

    public void HIghSonicDeviceItem()
    {
        dialogueText.text = "It appears that this device as described from its manual is used to lethally take out creatures that can hear well, most likely that is for the feline creature.";
        MainMenuController.Instance.ListOfItemsEncounter2[0] = true;
        //Must have code that shows item was picked up
        HighSonicDeviceButton.interactable = false;
    }

    public void IncedinaryItem()
    {
        dialogueText.text = "It appears that this device as described from its manual is used to burn organic material at around 678 C, i think this will work more than well against that abomination";
        MainMenuController.Instance.ListOfItemsEncounter3[0] = true;
        //Must have code that shows item was picked up
        IncedinaryDevice.interactable = false;
    }





}
