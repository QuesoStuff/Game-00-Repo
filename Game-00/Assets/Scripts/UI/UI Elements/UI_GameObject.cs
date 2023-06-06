using UnityEngine;
using UnityEngine.UI;

public class UI_GameObject : UI
{
    [SerializeField] internal Transform target;
    [SerializeField] internal Vector3 offset = new Vector3(0, 2, 0);
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Update_UI();
    }

    public override void Update_UI()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position + offset);
        textBox.transform.position = screenPos;
    }

}
