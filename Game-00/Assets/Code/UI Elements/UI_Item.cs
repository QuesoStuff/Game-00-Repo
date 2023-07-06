using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Item : UI
{
    private string item_UI_;

    public void UpdateItem_UI()
    {
        item_UI_ = string.Empty;
        if (ACTIVE.GetIsDashing())
        {
            item_UI_ += "[- Dashing -]";
        }
        if (ACTIVE.GetIsFrozen())
        {
            item_UI_ += "[- Frozen -]";
        }
    }

    public string StringFormatter()
    {
        return $"[ {item_UI_} ]";
    }

    public override void Update_UI()
    {
        UpdateItem_UI();
        string mess = StringFormatter();
        Update_UI_Text(mess);
    }
}
