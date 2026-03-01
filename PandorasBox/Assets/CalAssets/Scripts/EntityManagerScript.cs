using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using TMPro;

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
    public int TrueDefence;

    public List<string> HeldItems;
    public int ItemCount;
    public int MaxHeldItems;
    public List<string> PassiveEffects;
    public List<string> OffItems;
    public List<string> DefItems;
    public List<string> UtiItems;
    public ItemsScript Items;

    public List<string> ActionDictionary;

    public EntityManagerScript Target;

    public MonsterLoader Monster;

    public int Blocking;
    public int Wounded;

    public int CurrentMove;

    public TextMeshProUGUI OFFUI1;
    public TextMeshProUGUI OFFUI2;
    public TextMeshProUGUI DEFUI1;
    public TextMeshProUGUI DEFUI2;
    public TextMeshProUGUI UTIUI1;
    public TextMeshProUGUI UTIUI2;
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
        if (HeldItems.Count != 0 && IsPlayer)
        {
            foreach (string item in HeldItems)
            {
                Debug.Log(item);
                if (item == Items.Dictionary[1] || item == Items.Dictionary[3])
                {
                    OffItems.Add(item);
                    HeldItems.Remove(item);
                    OFFUI1.text = OffItems[0].ToString();
                    OFFUI2.text = OffItems[1].ToString();

                }
                else if (item == Items.Dictionary[2] || item == Items.Dictionary[5])
                {
                    DefItems.Add(item);
                    HeldItems.Remove(item);
                    DEFUI1.text = DefItems[0].ToString();
                    DEFUI2.text = DefItems[1].ToString();
                }
                else if (item == Items.Dictionary[0] || item == Items.Dictionary[4])
                {
                    UtiItems.Add(item);
                    HeldItems.Remove(item);
                    UTIUI1.text = UtiItems[0].ToString();
                    UTIUI2.text = UtiItems[1].ToString();
                }
            }
        }
        if (!IsPlayer)
        {
            if (Manager.Enemy1 == this)
            {
                string Readout = Monster.MonsterType.ToString() + "\n" + "HP: " + Health.ToString() + "\n" + HeldItems[0].ToString();
                Manager.UI1.text = Readout;
            }
            else if (!Manager.Enemy2 == this)
            {
                string Readout = Monster.MonsterType.ToString() + "\n" + "HP: " + Health.ToString() + "\n" + HeldItems[0].ToString();
                Manager.UI2.text = Readout;
            }
            else if (!Manager.Enemy3 == this)
            {
                string Readout = Monster.MonsterType.ToString() + "\n" + "HP: " + Health.ToString() + "\n" + HeldItems[0].ToString();
                Manager.UI3.text = Readout;
            }
            else if (!Manager.Enemy4 == this)
            {
                string Readout = Monster.MonsterType.ToString() + "\n" + "HP: " + Health.ToString() + "\n" + HeldItems[0].ToString();
                Manager.UI4.text = Readout;
            }
        }
        else
        {
            string Readout = "HP: " + Health.ToString();
            Manager.PUI.text = Readout;
        }
    }

    public void EndTurn()
    {
        Debug.Log("TurnEnd");
        CurrentMove = -1;
        Target = null;
        IsTurn = false;
        Manager.GetTurn().IsTurn = true;
    }

    public void PickAction(int Pick)
    {
        CurrentMove = Pick;
    }

    public void DoAction(int ActionType)
    {
        switch (ActionDictionary[ActionType])
        {
            case "Basic Attack":
                Debug.Log("Basic Attack");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "Basic Defend":
                Debug.Log("Basic Defend");
                Defence += 10;
                EndTurn();
                break;
            case "Basic Heal":
                Debug.Log("Basic Heal");
                Health += HealthRegen;
                EndTurn();
                break;
            case "HydraBite":
                Debug.Log("HydraBite");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "MinotaurAxe":
                Debug.Log("Minotaur");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "PixieSpell":
                Debug.Log("PixieSpell");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "RaptorClaw":
                Debug.Log("RaptorClaw");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "BasiliskGaze":
                Debug.Log("BasiliskGaze");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "GhostHaunt":
                Debug.Log("GhostHaunt");
                if (!IsPlayer)
                {
                    Target = Manager.Player;
                }
                if (Target != null)
                {
                    Target.TakeDamage(Attack);
                    Target = null;
                    EndTurn();
                }
                break;
            case "Offense 1":
                if (Target != null)
                {
                    if (OffItems[0] != null)
                    {
                        Items.UseItem(OffItems[0], Target, this);
                        OffItems.RemoveAt(0);
                        ItemCount--;
                        Target = null;
                        EndTurn();
                    }
                }
                break;
            case "Offense 2":
                if (Target != null)
                {
                    if (OffItems[1] != null)
                    {
                        Items.UseItem(OffItems[1], Target, this);
                        OffItems.RemoveAt(1);
                        ItemCount--;
                        Target = null;
                        EndTurn();
                    }
                }
                break;
            case "Offense 3":
                if (Target != null)
                {
                    Items.UseItem(OffItems[2], Target, this);
                    OffItems.RemoveAt(2);
                    ItemCount--;
                    Target = null;
                    EndTurn();
                }
                break;
            case "Offense 4":
                if (Target != null)
                {
                    Items.UseItem(OffItems[3], Target, this);
                    OffItems.RemoveAt(3);
                    ItemCount--;
                    Target = null;
                    EndTurn();
                }
                break;
            case "Defence 1":
                if (DefItems[0] != null)
                {
                    Target = Manager.Player;
                    Items.UseItem(DefItems[0], Target, this);
                    DefItems.RemoveAt(0);
                    ItemCount--;
                    Target = null;
                    EndTurn();
                }
                break;
            case "Defence 2":
                if (DefItems[1] != null)
                {
                    Target = Manager.Player;
                    Items.UseItem(DefItems[1], Target, this);
                    DefItems.RemoveAt(1);
                    ItemCount--;
                    Target = null;
                    EndTurn();
                }
                break;
            case "Defence 3":
                Target = Manager.Player;
                Items.UseItem(DefItems[2], Target, this);
                DefItems.RemoveAt(2);
                ItemCount--;
                Target = null;
                EndTurn();
                break;
            case "Defence 4":
                Target = Manager.Player;
                Items.UseItem(DefItems[3], Target, this);
                DefItems.RemoveAt(3);
                ItemCount--;
                Target = null;
                EndTurn();
                break;
            case "Utility 1":
                if (UtiItems[0] != null)
                {
                    Target = Manager.Player;
                    Items.UseItem(DefItems[0], Target, this);
                    UtiItems.RemoveAt(0);
                    ItemCount--;
                    Target = null;
                    EndTurn();
                }
                break;
            case "Utility 2":
                if (UtiItems[0] != null)
                {
                    Target = Manager.Player;
                    Items.UseItem(DefItems[1], Target, this);
                    UtiItems.RemoveAt(1);
                    ItemCount--;
                    Target = null;
                    EndTurn();
                }
                break;
            case "Utility 3":
                Target = Manager.Player;
                Items.UseItem(DefItems[2], Target, this);
                UtiItems.RemoveAt(2);
                ItemCount--;
                Target = null;
                EndTurn();
                break;
            case "Utility 4":
                Target = Manager.Player;
                Items.UseItem(DefItems[3], Target, this);
                UtiItems.RemoveAt(3);
                ItemCount--;
                Target = null;
                EndTurn();
                break;
        }
    }

    public void SelectTarget(int ID)
    {
        if (ID == 0) { Target = Manager.Player; Debug.Log("Player selected"); }
        else if (ID == 1) { Target = Manager.Enemy1; }
        else if (ID == 2) { Target = Manager.Enemy2; }
        else if (ID == 3) { Target = Manager.Enemy3; }
        else if (ID == 4) { Target = Manager.Enemy4; }
        Debug.Log(Target);
        DoAction(CurrentMove);
    }

    public void TakeDamage(int Damage)
    {
        if (IsPlayer && Blocking != 0)
        {
            if (Blocking == 1)
            {
                Blocking = 0;
                int NewTarget = Random.Range(1, 4);
                if (NewTarget == 1) { Target = Manager.Enemy1; }
                else if (NewTarget == 2) { Target = Manager.Enemy2; }
                else if (NewTarget == 3) { Target = Manager.Enemy3; }
                else if (NewTarget == 4) { Target = Manager.Enemy4; }
                Target.TakeDamage(Damage);
            }
            else if (Blocking == 2)
            {
                Blocking = 3;
                Damage = 0;
            }
        }
        if (Manager.Player.Blocking == 3)
        {
            Damage -= Damage / 2;
            Manager.Player.Blocking = 0;
        }
        if (Wounded > 0)
        {
            Damage += Wounded;
            Wounded -= 5;
        }
        Damage -= Defence;
        if (Damage < 0) { Damage = 1; }
        Health -= Damage;
        if (!IsPlayer)
        {
            if (Health <= 0)
            {
                Manager.EndRound(this);
                Destroy(this.gameObject);
                Debug.Log("enemy killed");
            }
        }
        else 
        {
            if (Health <= 0)
            {
                Manager.Dialogue.text = "Player health 0 you lose";
                this.gameObject.SetActive(false);
            }
        }
    }

    public void DoPassives()
    {
        for (int i = 0; i < PassiveEffects.Count; i++) 
        {
            switch (PassiveEffects[i])
            {
                case "HydraEffect":
                    PassiveEffects[i] = "Hydra";
                    HealthRegen += 10;
                    MaxHealth -= 10;
                    break;
                case "MinotaurEffect":
                    PassiveEffects[i] = "Minotaur";
                    MaxHealth += 10;
                    Speed = 5;
                    break;
                case "PixieEffect":
                    PassiveEffects[i] = "Pixie";
                    Speed += 5;
                    MaxHealth -= 10;
                    break;
                case "RaptorEffect":
                    PassiveEffects[i] = "Raptor";
                    Attack += 10;
                    MaxHealth = 10;
                    break;
                case "BasiliskEffect":
                    PassiveEffects[i] = "Basilisk";
                    Attack += 10;
                    Speed -= 5;
                    break;
                case "GhostEffect":
                    PassiveEffects[i] = "Ghost";
                    Defence += 5;
                    Attack -= 10;
                    break;
            }
        }
    }
}
