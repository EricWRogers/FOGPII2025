using UnityEngine;

public class Player : Tank
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.player = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
