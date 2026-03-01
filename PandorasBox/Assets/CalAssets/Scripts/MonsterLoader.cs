using UnityEngine;
using System.Collections.Generic;

public class MonsterLoader : MonoBehaviour
{
    public EntityManagerScript Link;
    public string MonsterType;
    public int DifficultyRange;
    public List<string> MonsterDictionary;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignMonster()
    {
        MonsterType = MonsterDictionary[Random.Range(0, MonsterDictionary.Count)];
        switch (MonsterType)
        {
            case "Hydra":
                Link.Health = 40;
                Link.MaxHealth = 40;
                Link.Attack = 10;
                Link.Defence = 2;
                Link.Speed = 5;
                Link.ActionDictionary.Add("HydraBite");
                Link.HeldItems.Add("Hydra Neck Brace");
                Link.PassiveEffects.Add("HydraEffect");
                break;

            case "Minotaur":
                Link.Health = 40;
                Link.MaxHealth = 40;
                Link.Attack = 15;
                Link.Defence = 5;
                Link.Speed = 10;
                Link.ActionDictionary.Add("MinotaurAxe");
                Link.HeldItems.Add("Minotaurs Massive Axe");
                Link.PassiveEffects.Add("MinotaurEffect");
                break;

            case "Pixie":
                Link.Health = 10;
                Link.MaxHealth = 10;
                Link.Attack = 12;
                Link.Defence = 10;
                Link.Speed = 20;
                Link.ActionDictionary.Add("PixieSpell");
                Link.HeldItems.Add("Pixies tiny Wing");
                Link.PassiveEffects.Add("PixieEffect");
                break;

            case "Raptor":
                Link.Health = 20;
                Link.MaxHealth = 20;
                Link.Attack = 12;
                Link.Defence = 7;
                Link.Speed = 12;
                Link.ActionDictionary.Add("RaptorClaw");
                Link.HeldItems.Add("Raptors Razor Claw");
                Link.PassiveEffects.Add("RaptorEffect");
                break;

            case "Basilisk":
                Link.Health = 50;
                Link.MaxHealth = 50;
                Link.Attack = 20;
                Link.Defence = 8;
                Link.Speed = 5;
                Link.ActionDictionary.Add("BasiliskGaze");
                Link.HeldItems.Add("Basilisks Glowing Eye");
                Link.PassiveEffects.Add("BasiliskEffect");
                break;

            case "Ghost":
                Link.Health = 5;
                Link.MaxHealth = 5;
                Link.Attack = 5;
                Link.Defence = 15;
                Link.Speed = 1;
                Link.ActionDictionary.Add("GhostHaunt");
                Link.HeldItems.Add("Ectoplasm");
                Link.PassiveEffects.Add("GhostEffect");
                break;
        }
    }
}
