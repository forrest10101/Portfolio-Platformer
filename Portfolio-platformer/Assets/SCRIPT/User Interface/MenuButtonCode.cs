using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButtonCode : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [SerializeField] private RectTransform visual;
    [SerializeField] private string sceneName;

    [SerializeField] private float hoverScale = 1.08f;
    [SerializeField] private float pressedScale = 0.94f;
    [SerializeField] private float animationSpeed = 16f;

    private Vector3 originalScale;
    private bool hovering;
    private bool pressing;
    private bool loading;

    private void Awake()
    {
        originalScale = visual.localScale;
    }

    private void Update()
    {
        float scale = pressing ? pressedScale : hovering ? hoverScale : 1f;
        Vector3 target = originalScale * scale;

        float blend = 1f - Mathf.Exp(
            -animationSpeed * Time.unscaledDeltaTime
        );

        visual.localScale = Vector3.Lerp(
            visual.localScale, target, blend
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            pressing = false;
    }

    public void LoadScene()
    {
        if (loading)
            return;

        if (string.IsNullOrWhiteSpace(sceneName) ||
            !Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogWarning("Add a valid scene to this button.", this);
            return;
        }

        loading = true;
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void OnDisable()
    {
        hovering = false;
        pressing = false;

        if (visual != null)
            visual.localScale = originalScale;
    }
}