using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Bullet_Main bullet_Main_;
    private static int activeBulletCount_;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetBulletCount(int newCOunt)
    {
        activeBulletCount_ = newCOunt;
        UI_Main.instance_.UI_Debug_.Update_UI_Text(activeBulletCount_);
    }
    public int GetBulletCount()
    {
        return activeBulletCount_;
    }

    public void Bullet_Speed()
    {
        if (activeBulletCount_ < 2)
        {
            bullet_Main_.bullet_Move_.Set(bullet_Main_.bullet_Move_.GetNormalSpeed() * 5);
        }
        else if (activeBulletCount_ < 5)
        {
            bullet_Main_.bullet_Move_.Set(bullet_Main_.bullet_Move_.GetNormalSpeed() / 2);
        }
        else if (activeBulletCount_ < 10)
        {
            bullet_Main_.bullet_Move_.Set(bullet_Main_.bullet_Move_.GetNormalSpeed() / 4);
        }
        else
        {
            bullet_Main_.bullet_Move_.Set(bullet_Main_.bullet_Move_.GetNormalSpeed() / 5);
        }
    }
    // accelerate 
    // shared speed 
    // misslie mode

}
