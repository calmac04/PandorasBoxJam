using UnityEngine;
using UnityEngine.UI;

public class EnemySelectScript : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject player;

    public void ActivateEnemies()
    {
        Button temp = enemy1.GetComponent<Button>();
        temp.interactable = true;
        temp = enemy2.GetComponent<Button>();
        temp.interactable = true;
        temp = enemy3.GetComponent<Button>();
        temp.interactable = true;
        temp = enemy4.GetComponent<Button>();
        temp.interactable = true;
        temp = player.GetComponent<Button>();
        temp.interactable = true;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
