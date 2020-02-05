using System.Collections.Generic;

public class Agent
{

    private Character character;
    private Agent superior;
    private List<Agent> subordinates;

    private Organisation organisation;

    public Agent(Character character)
    {
        this.character = character;
        this.subordinates = new List<Agent>();

    }

    public Agent AddSubordinate(Agent agent)
    {
        agent.superior = this;
        subordinates.Add(agent);
        return agent;
    }

    public Agent Superior
    {
        get { return superior; }
        set
        {
            if(superior != value)
            {
                if (superior != null)
                {
                    superior.subordinates.Remove(this);
                }
                superior = value;
                if (superior != null)
                {
                    superior.subordinates.Add(this);
                }
            }

        }
    }

    public bool IsLeader
    {
        get { return organisation.Leader == this; }
    }

    public void Destroy()
    {
        if (superior != null)
        {
            character = null;
            superior.subordinates.Remove(this);
            //superior.event - remove subordinate
            organisation = null;
            superior = null;
            subordinates = null;
        }
    }


    public Character Character
    {
        get
        {
            return character;
        }
    }

    public Organisation Organisation
    {
        get
        {
            return organisation;
        }
    }
}