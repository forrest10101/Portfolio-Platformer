using UnityEngine;
using System.Diagnostics;


public class KillObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("col");
            GameManager.Instance.LoseLife();
          

        }

    }
}
