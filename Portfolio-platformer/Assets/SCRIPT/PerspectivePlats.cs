using UnityEngine;

public class PerspectivePlats : MonoBehaviour
{
    public GameObject SideOnly;
    public GameObject FrontOnly;



    public void sideOnly()
    {
        SideOnly.SetActive(true);
        FrontOnly.SetActive(false);
    }


    public void frontOnly()
    {
        SideOnly.SetActive(false);
        FrontOnly.SetActive(true);
    }


}
