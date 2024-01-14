using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string[] mapNames = { "Forest", "Cave", "Snow" };
    private string randomMapName;
    [SerializeField] public FadeScreen fadeScreen; 
    public void StartGame()
    {
        randomMapName = mapNames[Random.Range(0, mapNames.Length)];
        StartCoroutine(LoadSceneWithFade(1f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadSceneWithFade (float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds (_delay);
        SceneManager.LoadScene(randomMapName);

    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
