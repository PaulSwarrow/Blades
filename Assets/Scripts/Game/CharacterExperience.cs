using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

public class BaseCharacterExperience: ICharacterExperience
{
    public readonly Dictionary<Character.Skill, AbstractProperty<int>.ValueModifier> skills;
    public BaseCharacterExperience()
    {
        skills = new Dictionary<Character.Skill, AbstractProperty<int>.ValueModifier>();
    }
    
    public void Apply(CharacterProfile profile)
    {
        foreach(KeyValuePair<Character.Skill, AbstractProperty<int>.ValueModifier> item in skills)
        {
            profile[item.Key].AddModifier(item.Value);
        }
    }
}