using System.ComponentModel;
using UnityEngine;

public class PerspectivePlats : MonoBehaviour
{
    public static PerspectivePlats Instance;

    public GameObject SideOnly;
    public GameObject FrontOnly;

    void start()
    {
        Instance = this;
    }

    public void sideOnly()
    {

        if (SideOnly != null && FrontOnly != null)
        {
            SideOnly.SetActive(true);
            FrontOnly.SetActive(false);
        }
    }


    public void frontOnly()
    {
        if (SideOnly != null && FrontOnly != null)
        {
            SideOnly.SetActive(false);
            FrontOnly.SetActive(true);
        }
    }


}
