using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] public List<UIListWrapper> complexOptionsWrappers_;

    public Action method_;
    protected int selectedIndex_ = 0;
    protected int selectedSubIndex_ = 0;
    public RectTransform icon_;
    protected float xOffset_ = 0;
    protected float yOffset_ = 0;
    protected bool isActive_ = true;




    public virtual void ResetMenu()
    {
        selectedIndex_ = 0;
        selectedSubIndex_ = 0;
    }

    protected virtual void Update()
    {
        if (!isActive_) return;

        HandleMoveUpDown();
        HandleMoveLeftRight();
        HandleSelectionInput();

        UpdateMenuCursor();
    }


    public void UpdateMenuCursor()
    {
        var complexOptions_ = complexOptionsWrappers_[selectedIndex_].uiList;
        Vector3 textBoxPos = complexOptions_[selectedSubIndex_].GetTextBox().rectTransform.localPosition;
        icon_.anchoredPosition = new Vector2(textBoxPos.x + xOffset_, textBoxPos.y + yOffset_);
    }


    protected virtual void HandleSelectionInput()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V))
        {
            GameMusic_Main.instance_.gameMusic_SFX_.IconSelect();
            HandleSelection();
        }
    }


    public void StartBlinking(int index, int subIndex)
    {
        var complexOptions_ = complexOptionsWrappers_[index].uiList;
        if (subIndex >= 0 && subIndex < complexOptions_.Count)
        {
            complexOptions_[subIndex].BlinkTextIndefinitely();
        }
    }

    public void StopBlinking(int index, int subIndex)
    {
        var complexOptions_ = complexOptionsWrappers_[index].uiList;
        if (subIndex >= 0 && subIndex < complexOptions_.Count)
        {
            complexOptions_[subIndex].StopBlinking();
        }
    }

    public void SetActive(bool isActive)
    {
        isActive_ = isActive;
        this.gameObject.SetActive(isActive_);

        if (isActive_)
            StartBlinking(selectedIndex_, selectedSubIndex_);
        else
            StopBlinking(selectedIndex_, selectedSubIndex_);
    }
    public void UpdateColorForUIList(List<UI> uiList, Color newColor)
    {
        foreach (var ui in uiList)
        {
            ui.Update_UI_Color(newColor);
        }
    }
    public void ToggleActive()
    {
        SetActive(!isActive_);
    }
    protected abstract void HandleMoveUpDown();
    protected abstract void HandleMoveLeftRight();
    public abstract void HandleSelection();
}
