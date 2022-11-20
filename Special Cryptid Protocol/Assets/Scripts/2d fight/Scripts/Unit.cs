using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	public int unitLevel;

	public int damage;

	public int maxHP;
	public int currentHP;
	public int maxAP;
	public int currentAP;

	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

    public bool APUse(int ap)
    {
		if (currentAP - ap <= 0) return false;
        currentAP -= ap;

        if (currentAP <= 0)
            return false;
        else
            return true;
    }

    public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

}
