using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase
{
    private int health;
    private int ammo;
    private float speed; 

    public int Health { get => health; set => health = value; }
    public int Ammo { get => ammo; set => ammo = value; }
    public float Speed { get => speed; set => speed = value; }

    public CharacterBase()
    {
        this.Health = 100;
        this.Ammo = 500;
    }
}
