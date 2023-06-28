using UnityEngine;
using UnityEngine.UI;

public class UI_GameObject : UI
{
    [SerializeField] public Transform target_;
    [SerializeField] public Vector3 offset_ = new Vector3(0, 2, 0);
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
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target_.position + offset_);
        textBox.transform.position = screenPos;
    }

}
