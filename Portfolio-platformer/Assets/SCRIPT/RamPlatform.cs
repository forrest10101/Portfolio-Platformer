using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class RamPlatform : MonoBehaviour
{
    public GameObject Set1;
    public GameObject Set2;

    void Start()
    {
        StartCoroutine(PlatformSwitch());
    }

    IEnumerator PlatformSwitch()
    {
        while (true)
        {
            Set1.SetActive(true);
            Set2.SetActive(false);

            yield return new WaitForSeconds(1);

            Set1.SetActive(false);
            Set2.SetActive(true);

            yield return new WaitForSeconds(1);
        }
    }


}
