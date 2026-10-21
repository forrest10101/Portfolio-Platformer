using UnityEngine;

public class Tester : MonoBehaviour
{

    private int Cam = 1;
    // 1 = Front  2 = Side
    public GameObject FrontCam;
    public GameObject SideCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Cam == 1)
            {
                FrontCam.SetActive(false);
                SideCam.SetActive(true);
                Cam = 2;

            }

            else if (Cam == 2)
            {
                FrontCam.SetActive(true);
                SideCam.SetActive(false);
                Cam = 1;
            }
        }


    }
}
