using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public List<GameObject> cardPrefabs;

    // public int cardsToSpawn = 0;
    public CardSpawner cardSpawner;


    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != this)
        {
            if (instance != null)
            {
                DestroyImmediate(instance.gameObject);
            }
        }
        instance = this;

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SendCardsToSpawn(int amount)
    {
        cardSpawner.CreateMatrix(amount);
    }
}
