using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    
    public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject panel;
	public GameObject itempanel;

	public ButtonEditor button;
	public TextMeshProUGUI b1Text;
	public TextMeshProUGUI b2Text;
	public TextMeshProUGUI b3Text;


	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public TMP_Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    public int numofattcks = 0;
    public int numofobst = 0;

    private int Checker = 0;
    public int checkme = 0;
	private int talkmeter= 0;

    public GameObject Heart;
    public GameObject Obst1;
    public GameObject Obst2;
    public GameObject Obst3;
	public GameObject enemybattle;
    private Vector3 Startingpos;


    public float speed;
    public float Sensitivity;
    private Vector2 MovePos;
	public int MaxX; 
    public int MaxY ;
    public int MinX ;
    public int MinY ;

	private void Awake()
	{
		//GameObject myGameObject;
		//myGameObject = GameObject.FindGameObjectWithTag("AllManager");
		

    }
	// Start is called before the first frame update
	void Start()
    {
		if (MainMenuController.Instance.ListOfItemsEncounter1[1] == true)
		{
			b1Text.text = "Gun";
		}
		if (MainMenuController.Instance.ListOfItemsEncounter2[1] == true)
		{
			b2Text.text = "H.S.D";
		}
        itempanel.SetActive(false);
        state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator GunAttack()
	{
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage * 3);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

	IEnumerator PlayerAttack()
	{
		
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		bool isDead;
		numofattcks = 0;
		int CurrentHealth = playerUnit.currentHP;
		dialogueText.text = enemyUnit.unitName + " attacks!";
        Startingpos = new Vector3(1, 1, 1);
        transform.position = Startingpos;
		MovePos = Startingpos;
		MaxX = 15;
		MaxY = 28;
		MinX = -33;
		MinY = -12;
		Sensitivity = 2;
		numofobst++;
        Checker = 1;
        checkme = 1;
		
        if (numofobst == 1)
        {
            Obst1.SetActive(true);
            Obst2.SetActive(false);
            Obst3.SetActive(false);

        }
        else if (numofobst == 2)
        {
            Obst1.SetActive(false);
            Obst2.SetActive(true);
            Obst3.SetActive(false);

        }
		else if(numofobst == 3)
        {
            Obst1.SetActive(false);
            Obst2.SetActive(false);
            Obst3.SetActive(true);

        }

        enemybattle.SetActive(false);


        yield return new WaitForSeconds(10f);

        enemybattle.SetActive(true);
        Checker = 0;
		checkme = 0;
		

		if (numofobst == 3)
		{
			numofobst = 0;
		}

		for(int i = 0; i < numofattcks; i++)
		{
            isDead = playerUnit.TakeDamage(enemyUnit.damage);
            playerHUD.SetHP(playerUnit.currentHP);
            if (isDead)
            {
                state = BattleState.LOST;
				numofattcks = 0;
                EndBattle();

            }
        }


		

		
		
		state = BattleState.PLAYERTURN;
		PlayerTurn();
		

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!, you succesfully killed the entity though perhaps there was another way?";
            StartCoroutine(waitup());
            Scene scene1 = SceneManager.GetActiveScene();
			MainMenuController.Instance.ViolentRoute[0] = true;
            if (scene1.name == "Scene2Fight1")
            {
                SceneManager.LoadScene("Scene5Encounter2");
            }
            else if (scene1.name == "Scene6Fight2")
            {
                SceneManager.LoadScene("Scene9Encounter3ContainmentRoom");
            }
            else if (scene1.name == "Scene10Fight3")
            {
                SceneManager.LoadScene("ViolentEnding");
            }
        } else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated, retreat for now";
			waitup();
			Scene scene = SceneManager.GetActiveScene();
			if(scene.name == "Scene2Fight1")
			{
				SceneManager.LoadScene("Scene1Encounter1");
			}
			else if(scene.name == "Scene6Fight2")
			{
                SceneManager.LoadScene("Scene5Encounter2");
            }
			else if(scene.name == "Scene10Fight3")
			{
                SceneManager.LoadScene("Scene9Encounter3ContainmentRoom");
            }
			
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator waitup()
	{
        yield return new WaitForSeconds(5f);

    }

	IEnumerator Talk()
	{
		//playerUnit.Heal(0);
		if (MainMenuController.Instance.ListOfItemsEncounter1[1] == false)
		{
            dialogueText.text = "Stop looking at me!";
        }
		else if(MainMenuController.Instance.ListOfItemsEncounter1[1] == true)
		{
            
			talkmeter++;
			if(talkmeter == 1)
			{
                dialogueText.text = "Wait.... you want to talk to me?";
                yield return new WaitForSeconds(5f);
                dialogueText.text = "You just want to talk, ok lets talk.";
                yield return new WaitForSeconds(5f);
				dialogueText.text = "Ok , you make sense, ill go back to my ce- i mean room, just dont forget to write that on your report.";
				yield return new WaitForSeconds(7f);
				MainMenuController.Instance.PeacefulRoute[0] = true;
				dialogueText.text = "You have peacefully resolved this encounter! And you did it peacefully, though know that it isnt always possible to do so, lets continue through this facility";
				yield return new WaitForSeconds(10f);
				MainMenuController.Instance.PeacefulRoute[0] = true;
				SceneManager.LoadScene("Scene5Encounter2");
            }
			
        }
		//playerHUD.SetHP(playerUnit.currentHP);
		

		yield return new WaitForSeconds(5f);
        // if we have glasses
        //dialogueText.text = "Wait.... you want to talk to me?";
        //if we dont have glasses
        //
        state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnTalkButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(Talk());
	}

    public void Gun()
    {
        if (state != BattleState.PLAYERTURN)
		{
            return;
        }
		else if (MainMenuController.Instance.ListOfItemsEncounter1[0] == true)
		{
            Scene scene2 = SceneManager.GetActiveScene();
            if (scene2.name == "Scene6Fight2")
			{
				dialogueText.text = "I dont have any more ammo for the gun!";
				StartCoroutine(waitup());
				return;
			}
			bool Apused = playerUnit.APUse(6);
            playerHUD.SetAP(playerUnit.currentAP);
            if (Apused)
			{
				itempanel.SetActive(false);
                StartCoroutine(GunAttack());
            }
			else
			{
				dialogueText.text = "Im too tired to do that";
				StartCoroutine(waitup());
				return;
			}
           
        }
		else
		{
			dialogueText.text = "I have nothing to use";
			return;
		}
        
    }

    public void HSD()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        else if (MainMenuController.Instance.ListOfItemsEncounter2[0] == true)
        {
            Scene scene2 = SceneManager.GetActiveScene();
            if (scene2.name == "Scene10Fight3")
            {
                dialogueText.text = "Its fried, guess it was only limited use...";
                StartCoroutine(waitup());
                return;
            }
            bool Apused = playerUnit.APUse(6);
            playerHUD.SetAP(playerUnit.currentAP);
            if (Apused)
            {
                itempanel.SetActive(false);
                StartCoroutine(GunAttack());
            }
            else
            {
                dialogueText.text = "Im too tired to do that";
                StartCoroutine(waitup());
                return;
            }

        }
        else
        {
            dialogueText.text = "I have nothing to use";
            return;
        }

    }

    public UnityEngine.SceneManagement.Scene GetActiveScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    private void FixedUpdate()
	{
		if (Checker == 0)
		{
			panel.SetActive(false);
            

        }


		if (Checker == 1)
		{
			
            panel.SetActive(true);
            float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
            float vertical = Input.GetAxis("Vertical") * Sensitivity;
            MovePos.x += horizontal;
            MovePos.y += vertical;

            MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
            MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

            Heart.transform.position = Vector2.Lerp(transform.position, MovePos, speed * Time.deltaTime);
        }
        
    }

}
