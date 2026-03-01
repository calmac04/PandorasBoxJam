using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ItemsScript : MonoBehaviour
{
    public List<string> Dictionary = new List<string> { "Hydra Neck Brace", "Minotaurs Massive Axe", "Pixies Tiny Wing", "Raptors Razor Claw", "Basilisks Glowing Eye", "Ectoplasm"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Dictionary = new List<string> { "Hydra Neck Brace", "Minotaurs Massive Axe", "Pixies Tiny Wing", "Raptors Razor Claw", "Basilisks Glowing Eye", "Ectoplasm" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItem(string Item, EntityManagerScript Target, EntityManagerScript User)
    {
        switch (Item)
        {
            case "Hydra Neck Brace":
                Target.Health += Target.MaxHealth / 2;
                break;
            case "Minotaurs Massive Axe":
                Target.TakeDamage(Target.Health / 2);
                break;
            case "Pixies Tiny Wing":
                Target.Blocking = 1;
                break;
            case "Raptors Razor Claw":
                Target.Wounded = User.Attack;
                Target.TakeDamage(User.Attack * 2);
                break;
            case "Basilisks Glowing Eye":
                Target.Speed = 0;
                Target.Defence = 0;
                break;
            case "Ectoplasm":
                Target.Blocking = 2;
                break;
        }
    }


}
