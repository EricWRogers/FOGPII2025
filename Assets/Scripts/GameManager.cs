using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public bool isPlaying = true;

    public Player player;
    public List<Tank> enemies;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // optional
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            // awake
            Destroy(this);
            return;
        }
    }
}
