using Unity.VisualScripting;
using UnityEngine;

public class RamPlatform : MonoBehaviour
{
    public static RamPlatform Instance;


    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    void Awake()
    {
        Instance = this;

        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }


}
