using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public int CurrentLvl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LvlUnlocked[CurrentLvl] = true;
            SceneManager.LoadScene("GAME WIN");

        }

    }
}
