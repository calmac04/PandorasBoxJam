using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EntityManagerScript : MonoBehaviour
{
    public bool IsPlayer;
    public CombatSystemScript Manager;
    public bool IsTurn;

    public int Health;
    public int MaxHealth;
    public int HealthRegen;

    public int Attack;

    public float Speed;
    public int TrueSpeed;

    public int Defence;

    public List<string> HeldItems;
    public int MaxHeldItems;
    public List<string> PassiveEffects;

    public List<string> ActionDictionary;

    public EntityManagerScript Target;

    public MonsterLoader Monster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Manager = GameObject.FindWithTag("Manager").GetComponent<CombatSystemScript>();
        if (!IsPlayer)
        {
            MaxHeldItems = 1;
        }
        else
        {
            MaxHeldItems = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTurn)
        {
            string message = IsPlayer.ToString() + " " + Health.ToString();
            //Debug.Log(message);
            if (IsPlayer) {DoPassives();}
        }
        if (Health < 0 && !IsPlayer)
        {
            Manager.EndRound(this);
            Destroy(this.gameObject);
        }
    }

    public void EndTurn()
    {
        Health += HealthRegen / 2;
        if (Health>MaxHealth) { Health = MaxHealth; }
        IsTurn = false;
        Manager.GetTurn().IsTurn = true;
    }

    public void DoAction(int ActionType)
    {
        switch (ActionDictionary[ActionType])
        {
            case "Basic Attack":
                SelectTarget().TakeDamage(Attack);
                break;
        }
        EndTurn();
    }

    EntityManagerScript SelectTarget()
    {
        int ID;
        if (!IsPlayer) { ID = 0; }
        else { ID = 0; }// access ui to select target 
        if (ID == 0) { Target = Manager.Player; }
        else if (ID == 1) { Target = Manager.Enemy1; }
        else if (ID == 2) { Target = Manager.Enemy2; }
        else if (ID == 3) { Target = Manager.Enemy3; }
        else if (ID == 4) { Target = Manager.Enemy4; }
        return Target;
    }

    public void TakeDamage(int Damage)
    {
        Damage -= Defence;
        if (Damage < 0) { Damage = 0; }
        Damage += 1;
        Health -= Damage;
    }

    void DoPassives()
    {
        foreach(string effect in PassiveEffects)
        {
            switch (effect)
            {
                case "null":
                    break;
            }
        }
    }
}
