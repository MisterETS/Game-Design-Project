using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public Button Key;
    public Button Flame;
    public Button Page;
    public Button Gun;
    public Button Glasses;
    public Button Screw;
    public Button HSD;
    public Button invbutton8;
    public Button invbutton9;
    public TMP_Text dialogueText;

    private void Update()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter1[0] == true)
        {
            Gun.interactable = true;
            Gun.GetComponent<Image>().enabled = true;
        }
        else
        {
            Gun.interactable = false;
            Gun.GetComponent<Image>().enabled = false;
        }



        if (MainMenuController.Instance.ListOfItemsEncounter1[1] == true)
        {
            Glasses.interactable = true;
            Glasses.GetComponent<Image>().enabled = true;
        }
        else
        {
            Glasses.interactable = false;
            Glasses.GetComponent<Image>().enabled = false;
        }


        if (MainMenuController.Instance.ListOfItemsEncounter1[2] == true)
        {
            Screw.interactable = true;
            Screw.GetComponent<Image>().enabled = true;
        }
        else
        {
            Screw.interactable = false;
            Screw.GetComponent<Image>().enabled = false;
        }

        if (MainMenuController.Instance.ListOfItemsEncounter2[0] == true)
        {
            HSD.interactable = true;
            HSD.GetComponent<Image>().enabled = true;
        }
        else
        {
            HSD.interactable = false;
            HSD.GetComponent<Image>().enabled = false;
        }


        if (MainMenuController.Instance.ListOfItemsEncounter2[1] == true)
        {
            Page.interactable = true;
            Page.GetComponent<Image>().enabled = true;
        }
        else
        {
            Page.interactable = false;
            Page.GetComponent<Image>().enabled = false;
        }

        if (MainMenuController.Instance.ListOfItemsEncounter2[2] == true)
        {
            Key.interactable = true;
            Key.GetComponent<Image>().enabled = true;
        }
        else
        {
            Key.interactable = false;
            Key.GetComponent<Image>().enabled = false;
        }

        if (MainMenuController.Instance.ListOfItemsEncounter3[0] == true)
        {
            Flame.interactable = true;
            Flame.GetComponent<Image>().enabled = true;
        }
        else
        {
            Flame.interactable = false;
            Flame.GetComponent<Image>().enabled = false;
        }
    }
   

    public void GunBut()
    {
        dialogueText.text = "A handgun, useful when it has ammo and can be used in a fight if the need arises";
    }

    public void HSDBut()
    {
        dialogueText.text = "A high frequency emitter, while it isn't perceivable to the human ear this tone will shut down the brain function of those who can perceive it, for emergancy use only";
    }
    public void KeyBut()
    {
        dialogueText.text = "The janitors keycard, can be used to open the janitors maintenance closet, i believe there is a maintenance tunnel in there allowing for an easy escape";
    }

    public void FlameBut()
    {
        dialogueText.text = "A handheld flamethrower,good for incinerating flesh";
    }

    public void PageBut()
    {
        dialogueText.text = "'The cat gives nonsense riddles, it simply wants you to make a fool of yourself for its amusement' - Dr Langheart.,P.S The answers are 'I know him, he's me!','A hole','Your riddles are hard'";
    }

    public void ScrewDriverBut()
    {
        dialogueText.text = "A screwdriver, can be used to take out screws. I believe i saw a vent somewhere";
    }

    public void GlassesBut()
    {
        dialogueText.text = "A pair of glasses, hard to look through but recalling that terminal, that ape entity doesnt like to be looked at without them, interesting.";
    }
}
