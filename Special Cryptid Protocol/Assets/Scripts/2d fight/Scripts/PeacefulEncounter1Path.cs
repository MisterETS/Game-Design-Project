using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;


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

    private void Start()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter1[1] == true)
        {
            GlassesButton.interactable = false;
            
        }

        if (MainMenuController.Instance.ListOfItemsEncounter2[1] == true)
        {
            PageOfAnsButton.interactable = false;
            PageOfAnsButton.GetComponent<Image>().enabled = false;
        }

        


    }


    public void GlassesItem()
    {
        dialogueText.text = "I take a pair of glasses, putting them on makes it hard to see but these should be useful.";
        MainMenuController.Instance.ListOfItemsEncounter1[1] = true;
        //Must have code that shows item was picked up
        GlassesButton.interactable = false;
        
    }

    public void AnswerPageItem()
    {
        dialogueText.text = " 'The cat gives nonsense riddles, it simply wants you to make a fool of yourself for its amusement' - Dr Langheart.,P.S The answers are 'I know him, he's me!','A hole','Your riddles are hard' "; 
        MainMenuController.Instance.ListOfItemsEncounter2[1] = true;
        //Must have code that shows item was picked up
        PageOfAnsButton.interactable = false;
        PageOfAnsButton.GetComponent<Image>().enabled = false;
    }

    public void CryoFreeze()
    {
        if (MainMenuController.Instance.ListOfItemsEncounter3[1] == true)
        {

            dialogueText.text = "It appears that after going through some of the documents lying on the desk , THis device is capable of putting any organic material in Absolute zero status, but can also revive the organic materilal, perhaps i can use it to freeze that creature? All i need is to get the power on and come back here";
            MainMenuController.Instance.PeacefulRoute[2] = true;
            //Must have code that shows item was picked up
            CryoFreezeButt.interactable = false;
            CryoFreezeButt.GetComponent<Image>().enabled = false;
            Scene scene1 = SceneManager.GetActiveScene();
            if (MainMenuController.Instance.PeacefulRoute[0] == true && MainMenuController.Instance.PeacefulRoute[1] == true && MainMenuController.Instance.PeacefulRoute[2] == true)
            {
                SceneManager.LoadScene("ContainmentEnding");
            }
        }
        else
        {
            dialogueText.text = "This button runs a cyrofreeze of the room subject 666 is currently in, however the button is currently off.";
        }
        
    }

    public void ComputerSasquatch()
    {
        dialogueText.text = "Subject 013 designation SASQUATCH, is a highly emotional being which wishes not to be percieved by anyone. It can be peacefully reasoned with if protective glasses that obscure the vision are used.";
        
        //Must have code that shows item was picked up
        
    }

    public void LeaveScene()
    {
        SceneManager.LoadScene("Scene1Encounter1");
    }

}
