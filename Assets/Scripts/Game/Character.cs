using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Character
{

    public enum Belief
    {
        liberal, religios, fatalism, imperialism

    }

    public enum Skill
    {
        conspiracy, stealth, prison_break
    }

    private CharacterProfile profile;
    private List<Agent> positions;

    public Character()
    {
        profile = new CharacterProfile();
        
        
    }

    // metthods:

    public Agent GetAgent(Organisation organization)
    {
        foreach(Agent a in positions)
        {
            if(a.Organisation == organization)
            {
                return a;
            }
        }
        Agent agent = new Agent(this);
        return agent;
    }

    public void AddExperience(ICharacterExperience experience)
    {
        experience.Apply(profile);
    }

    //accessors:
    public IEnumerator<Agent> GetPositions()
    {
        return positions.GetEnumerator();
    }
    public int GetProperty(Skill skill, IGameContext context = null)
    {   
        return profile[skill].GetValue(context);
    }
        
    public int this[Skill key]
    {
        get
        {
            return GetProperty(key);
        }
    }

    public int this[Belief key]
    {
        get
        {
            return profile.beliefs[key];
        }
    }



}
