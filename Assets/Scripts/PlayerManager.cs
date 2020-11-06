using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UIManager uiManager;

    private float life = 1f;

    public void hurt(float value)
    {
        life -= value;
        if(life < 0f)
        {
            uiManager.setPlayerLife(0f);
            uiManager.Lose();
            return;
        }
        uiManager.setPlayerLife(life);
    }
}
