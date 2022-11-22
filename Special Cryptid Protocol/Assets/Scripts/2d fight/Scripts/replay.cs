using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{

    public void replaybut()
    {
        MainMenuController.Instance.ListOfItemsEncounter1[0] =false;
        MainMenuController.Instance.ListOfItemsEncounter1[1] =false;
        MainMenuController.Instance.ListOfItemsEncounter1[2] = false;
        MainMenuController.Instance.ListOfItemsEncounter2[0] = false;
        MainMenuController.Instance.ListOfItemsEncounter2[1] = false;
        MainMenuController.Instance.ListOfItemsEncounter2[2] = false;
        MainMenuController.Instance.ListOfItemsEncounter3[0] = false;
        MainMenuController.Instance.ListOfItemsEncounter3[1] = false;
        MainMenuController.Instance.ListOfItemsEncounter3[2] = false;

        MainMenuController.Instance.PeacefulRoute[0] = false;
        MainMenuController.Instance.PeacefulRoute[1] = false;
        MainMenuController.Instance.PeacefulRoute[2] = false;
        MainMenuController.Instance.ViolentRoute[0] = false;
        MainMenuController.Instance.ViolentRoute[1] = false;
        MainMenuController.Instance.ViolentRoute[2] = false;
        MainMenuController.Instance.EscapeRoute[0] = false;
        MainMenuController.Instance.EscapeRoute[1] = false;
        MainMenuController.Instance.EscapeRoute[2] = false;
        Scene scene1 = SceneManager.GetActiveScene();

        SceneManager.LoadScene("MainMenu");


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
