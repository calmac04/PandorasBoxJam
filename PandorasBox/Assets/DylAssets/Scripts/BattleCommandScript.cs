using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCommandScript : MonoBehaviour
{
    public GameObject offenseChildren;
    public GameObject defenseChildren;
    public GameObject utilityChildren;
    public GameObject dialogueBox;
    TMP_Text dialogue;
    List<GameObject> selectors = new List<GameObject>();
    List<bool> selectorVisibility = new List<bool> { true, true, true };

    List<string> lines = new List<string>
    {
        "What will you do?", //Placeholder text
        "Deal moderate damage to the enemy.", //Basic Attack
        "Defend against enemy attacks this turn.", //Basic Defend
        "Restore your own health.", //Basic Heal
    };

    //Will either activate or deactivate the selector children and corresponding selector children
    public void SelectorSwitch(int selector)
    {
        if (selectorVisibility[selector] == true)
        {
            DeactivateSelector(selector);
        }
        else
        {
            ActivateSelector(selector);
        }
        
        //Checks if other selectors are active
        for (int i = 0; i < 3; i++)
        {
            if (i == selector) { continue; }
            if (selectorVisibility[i] == true)
            {
                DeactivateSelector(i);
            }
        }
    }

    void DeactivateSelector(int selector)
    {
        selectors[selector].SetActive(false);
        selectorVisibility[selector] = false;
    }

    void ActivateSelector(int selector)
    {
        selectors[selector].SetActive(true);
        selectorVisibility[selector] = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Append selectors
        selectors.Add(offenseChildren);
        selectors.Add(defenseChildren);
        selectors.Add(utilityChildren);

        for (int i = 0; i < 3; i++)
        {
            DeactivateSelector(i);
        }

        GameObject tempDia = dialogueBox.transform.GetChild(1).gameObject;
        dialogue = tempDia.GetComponent<TMP_Text>();
        dialogue.text = lines[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
