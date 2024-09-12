using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Pokemon
{
    public string name;
    public int level;
    public int hp;
    public int maxHp;
    public int attack;
    public int defense;
    public int speed;
    public int exp;
    public int maxExp;
    public PokemonSkill[] skills = new PokemonSkill[4];
}
