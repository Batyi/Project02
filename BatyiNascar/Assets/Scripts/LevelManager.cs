using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class LevelManager : MonoBehaviour {
	public void Play_Level1() {
        SceneManager.LoadScene("Level1");
	}
    public void Play_Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Play_Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Quit () {
        Application.Quit();
	}
}
