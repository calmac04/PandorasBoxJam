using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleCommandScript : MonoBehaviour
{
    public GameObject offenseChildren;
    public GameObject defenseChildren;
    public GameObject utilityChildren;
    List<GameObject> selectorChildren = new List<GameObject>();
    List<bool> selectorVisibility = new List<bool> { true, true, true };

    //Will either activate or deactivate the selector children and corresponding selector children
    public void SelectorSwitch(int selector)
    {
        if (selectorVisibility[selector] == true)
        {
            DeactivateSelector(selectorChildren[selector]);
        }
        else
        {
            ActivateSelector(selectorChildren[selector]);
        }
        
        //Checks if other selectors are active
        for (int i = 0; i < 3; i++)
        {
            if (i == selector) { continue; }
            if (selectorVisibility[i] == true)
            {
                DeactivateSelector(selectorChildren[i]);
            }
        }
    }

    void DeactivateSelector(GameObject selectorChildren)
    {
        selectorChildren.SetActive(false);
    }

    void ActivateSelector(GameObject selectorChildren)
    {
        selectorChildren.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Append selectors
        selectorChildren.Add(offenseChildren);
        selectorChildren.Add(defenseChildren);
        selectorChildren.Add(utilityChildren);

        for (int i = 0; i < 3; i++)
        {
            DeactivateSelector(selectorChildren[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
