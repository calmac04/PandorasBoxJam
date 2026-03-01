using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics; 
using UnityEngine;

public class CombatSystemScript : MonoBehaviour
{
    public EntityManagerScript Player;
    public EntityManagerScript Enemy1;
    public EntityManagerScript Enemy2;
    public EntityManagerScript Enemy3;
    public EntityManagerScript Enemy4;
    public TextMeshProUGUI UI1;
    public TextMeshProUGUI UI2;
    public TextMeshProUGUI UI3;
    public TextMeshProUGUI UI4;
    public List<KeyValuePair<EntityManagerScript,float>> TurnOrder = new List<KeyValuePair<EntityManagerScript, float>>();
    public List<EntityManagerScript> Entities;
    public List<float> Speeds;
    public EntityManagerScript CurrentCombatant;
    public GameObject MonsterPrefab;
    public int roundcount = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnMonster();
        CalcTurns();
        for (int i = 0; i < TurnOrder.Count; i++)
        {
            Debug.Log(TurnOrder[i].ToString());
        }
        GetTurn().IsTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.IsTurn)
        {
            AITurn(CurrentCombatant);
        }
    }

    void CalcTurns()
    {
        if (TurnOrder.Count > 0) { TurnOrder.Clear(); }
        
        float loopcount = Player.Speed;
        for (int i = 0; i <= (loopcount / 20); i++)
        {
            float temp = 0;
            if (Player.Speed >= 20)
            {
                temp = Player.Speed;
                Player.Speed = 20;
            }
            TurnOrder.Add(new KeyValuePair<EntityManagerScript, float>(Player,Player.Speed));
            Player.Speed = temp;
            if (Player.Speed > 20)
            {
                Player.Speed -= 20;
            }
        }
        if (Enemy1 != null) { TurnOrder.Add(new KeyValuePair<EntityManagerScript, float>(Enemy1,Enemy1.Speed)); }
        if (Enemy2 != null) { TurnOrder.Add(new KeyValuePair<EntityManagerScript, float>(Enemy2, Enemy2.Speed)); }
        if (Enemy3 != null) { TurnOrder.Add(new KeyValuePair<EntityManagerScript, float>(Enemy3, Enemy3.Speed)); }
        if (Enemy4 != null) { TurnOrder.Add(new KeyValuePair<EntityManagerScript, float>(Enemy4, Enemy4.Speed)); }
        TurnOrder.Sort((a,b) => b.Value.CompareTo(a.Value));
        for (int i = 0; i < TurnOrder.Count; i++)
        {
            Entities.Add(TurnOrder[i].Key);
            Speeds.Add(TurnOrder[i].Value);
        }
        Player.Speed = Player.TrueSpeed;
    }

    public EntityManagerScript GetTurn()
    {
        if (Entities.Count != 0)
        {
            CurrentCombatant = Entities[0];
            Debug.Log(CurrentCombatant.ToString());
            Entities.RemoveAt(0);
            Speeds.RemoveAt(0);
            if (CurrentCombatant == Player)
            {
                Player.Defence = Player.TrueDefence;
            }
            return CurrentCombatant;
        }
        else
        {
            CalcTurns();
            CurrentCombatant = Entities[0];
            Debug.Log(CurrentCombatant.ToString());
            Entities.RemoveAt(0);
            Speeds.RemoveAt(0);
            return CurrentCombatant;
        }
    }

    public void EndRound(EntityManagerScript Enemy)
    {
        roundcount++;
        Player.Health += Player.HealthRegen / 2;
        if (Player.Health > Player.MaxHealth) { Player.Health = Player.MaxHealth; }
        if (Player.ItemCount < Player.MaxHeldItems)
        {
            Player.HeldItems.Add(Enemy.HeldItems[0]);
            Debug.Log("you acquired: " + Enemy.HeldItems[0]);
            Player.PassiveEffects.Add(Enemy.PassiveEffects[0]);
            Player.ItemCount += 1;
            Player.DoPassives();
        }
        SpawnMonster();
    }

    void SpawnMonster()
    {
        Enemy1 = null;
        Enemy2 = null;
        Enemy3 = null;
        Enemy4 = null;
        for (int i = 0;i < roundcount+1;i++)
        {
            if (Enemy1 == null)
            {
                Enemy1 = Instantiate(MonsterPrefab).GetComponent<EntityManagerScript>();
                Enemy1.Monster.AssignMonster();
            }
            else if (Enemy2 == null)
            {
                Enemy2 = Instantiate(MonsterPrefab).GetComponent<EntityManagerScript>();
                Enemy2.Monster.AssignMonster();
            }
            else if (Enemy3 == null)
            {
                Enemy3 = Instantiate(MonsterPrefab).GetComponent<EntityManagerScript>();
                Enemy3.Monster.AssignMonster();
            }
            else if (Enemy4 == null)
            {
                Enemy4 = Instantiate(MonsterPrefab).GetComponent<EntityManagerScript>();
                Enemy4.Monster.AssignMonster();
            }
            else
            {
                Debug.Log("Error: Too Many Enemies");
            }
        }
    }

    void AITurn(EntityManagerScript AI)
    {
        AI.DoAction(0);
    }
}
