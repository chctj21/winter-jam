using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private string[] mapNames = { "Forest", "Cave", "Snow" };
    private string randomMapName;

    public void RestartGame()
    {
        randomMapName = mapNames[Random.Range(0, mapNames.Length)];
        SceneManager.LoadScene("Forest");
    }

}
