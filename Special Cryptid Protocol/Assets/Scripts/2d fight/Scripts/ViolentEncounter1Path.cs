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





}
