using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject panel;

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


    // Start is called before the first frame update
    void Start()
    {
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
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator Talk()
	{
		//playerUnit.Heal(0);

		//playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "Wait.... you want to talk to me?";

		yield return new WaitForSeconds(5f);
        // if we have glasses
        //dialogueText.text = "Wait.... you want to talk to me?";
        //if we dont have glasses
        //dialogueText.text = "Stop looking at me!";
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
