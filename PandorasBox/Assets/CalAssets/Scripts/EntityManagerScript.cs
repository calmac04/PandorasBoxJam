using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityManagerScript : MonoBehaviour
{
    public bool IsPlayer;
    public int Health;
    public int MaxHealth;
    public int HealthRegen;
    public List<GameObject> ItemEffects;
    public int Attack;
    public List<GameObject> HeldItems;
    public int MaxHeldItems;
    public int TrueSpeed;
    public float Speed;
    public int Defence;
    public Dictionary<int, GameObject> ItemDictionary;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
