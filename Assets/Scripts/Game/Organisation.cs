using UnityEngine;
using System.Collections.Generic;

public class Organisation
{
    private List<Agent> agents;

    public readonly Agent Leader;
    public Organisation()
    {
        Leader = new Agent(null);
    }
}