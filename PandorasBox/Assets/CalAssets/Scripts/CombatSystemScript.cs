using System;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystemScript : MonoBehaviour
{
    public EntityManagerScript Player;
    public EntityManagerScript Enemy1;
    public EntityManagerScript Enemy2;
    public EntityManagerScript Enemy3;
    public EntityManagerScript Enemy4;
    public List<KeyValuePair<EntityManagerScript,float>> TurnOrder = new List<KeyValuePair<EntityManagerScript, float>>();
    public List<EntityManagerScript> Entities;
    public List<float> Speeds;
    public EntityManagerScript CurrentCombatant;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CalcTurns();
        for (int i = 0; i < TurnOrder.Count; i++)
        {
            Debug.Log(TurnOrder[i].ToString());
        }
        GetTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalcTurns()
    {
        //if (TurnOrder.Count > 0) { TurnOrder.Clear(); }
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

    void GetTurn()
    {
        if (Entities.Count != 0)
        {
            CurrentCombatant = Entities[0];
            Debug.Log(CurrentCombatant.ToString());
            Entities.RemoveAt(0);
            Speeds.RemoveAt(0);
            
        }
        else
        {
            CalcTurns();
        }
    }
}
