using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;
    public bool[] ListOfItemsEncounter1 = new bool[5];
    public bool[] ListOfItemsEncounter2 = new bool[5];
    public bool[] ListOfItemsEncounter3 = new bool[5];
    public bool[] PeacefulRoute = new bool[5];
    public bool[] ViolentRoute = new bool[5];
    public bool[] EscapeRoute = new bool[5];
    //public bool[] ListOfItemsEncounter4 = new bool[5];
    //ListOfItemsEncounter1[0] is Gun,ListOfItemsEncounter1[1] is  pair of glasses, ListOfItemsEncounter1[2] is screwdriver
    //ListOfItemsEncounter2 and 3 are to be discussed 
    //There are 3 scenes so far , so it needs to be discussed on how the endings will be obtained
    private void Start()
    {
       /* ListOfItemsEncounter1[0] = false;
        ListOfItemsEncounter1[1] = false;
        ListOfItemsEncounter1[2] = false;
        ListOfItemsEncounter1[3] = false;
        ListOfItemsEncounter1[4] = false;

        ListOfItemsEncounter2[0] = false;
        ListOfItemsEncounter2[1] = false;
        ListOfItemsEncounter2[2] = false;
        ListOfItemsEncounter2[3] = false;
        ListOfItemsEncounter2[4] = false;


        ListOfItemsEncounter3[0] = false;
        ListOfItemsEncounter3[1] = false;
        ListOfItemsEncounter3[2] = false;
        ListOfItemsEncounter3[3] = false;
        ListOfItemsEncounter3[4] = false;

        PeacefulRoute[0] = false;
        PeacefulRoute[1] = false;
        PeacefulRoute[2] = false;

        ViolentRoute[0] = false;
        ViolentRoute[1] = false;
        ViolentRoute[2] = false;

        EscapeRoute[0] = false;
        EscapeRoute[1] = false;
        EscapeRoute[2] = false;*/
    }

    




    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        Scene scene1 = SceneManager.GetActiveScene();

    }

    private void Update()
    {
       
    }


}
