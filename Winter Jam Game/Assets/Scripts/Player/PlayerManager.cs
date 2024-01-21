using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //singleton design pattern, allows us to access the player from any script
    public static PlayerManager instance;
    public Player player;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else { instance = this; }
    }

}
