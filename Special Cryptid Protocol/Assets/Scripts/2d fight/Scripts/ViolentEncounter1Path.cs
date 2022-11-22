using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;



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
        dialogueText.text = "With this I can fight the monsters, though I wonder if there isn't a better option to deal with them.";
        MainMenuController.Instance.ListOfItemsEncounter1[0] = true;
        //Must have code that shows item was picked up
        GunButton.interactable = false;
        GunButton.GetComponent<Image>().enabled = false;
    }

    public void LeaveScene()
    {
        SceneManager.LoadScene("Scene1Encounter1");
    }

    public void HIghSonicDeviceItem()
    {
        dialogueText.text = "A high frequency emitter, while it isn't perceivable to the human ear this tone will shut down the brain function of those who can perceive it, for emergancy use only.";
        MainMenuController.Instance.ListOfItemsEncounter2[0] = true;
        //Must have code that shows item was picked up
        HighSonicDeviceButton.interactable = false;
        HighSonicDeviceButton.GetComponent<Image>().enabled = false;
    }

    public void IncedinaryItem()
    {
        dialogueText.text = "You pick up the Incendary Device from the shredded up corpse of a guard, a handheld flamethrower";
        MainMenuController.Instance.ListOfItemsEncounter3[0] = true;
        //Must have code that shows item was picked up
        IncedinaryDevice.interactable = false;
        IncedinaryDevice.GetComponent<Image>().enabled = false;
    }


    private void Update()
    {
        if(MainMenuController.Instance.ListOfItemsEncounter1[0] == true)
        {
            GunButton.interactable = false;
            if (MainMenuController.Instance.ListOfItemsEncounter2[0] == true)
            {
                HighSonicDeviceButton.interactable = false;
                if (MainMenuController.Instance.ListOfItemsEncounter3[0] == true)
                {
                    IncedinaryDevice.interactable = false;
                }
            }
        }


        
        
    }





}
