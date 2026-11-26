using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Lives = 3;
    public bool[] LvlUnlocked = { true, false, false, false, false, false };

    public GameObject Player;
    

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MAIN MENU");
        Lives = 3;
        LvlUnlocked = new bool[] { true, true, false, false, false, false }; 
    }


    public void LoseLife()
    {
        Lives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Lives <= 0)
        {
            GameOver();
        }
    }
}
