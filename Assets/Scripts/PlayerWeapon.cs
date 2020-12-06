/**
    **PlayerWeapon.cs**

    This file focus on the controller's input to help with player's movement
    
    ----

    *Created by Michael Chang on 11-27-2020*

    *Copyright (c) 2020. All rights reserved*
*/

using UnityEngine;

[System.Serializable]
public class PlayerWeapon : MonoBehaviour
{
    public string name = "Glock";

    public float damage = 10.0f;
    public float range = 100.0f;

}
