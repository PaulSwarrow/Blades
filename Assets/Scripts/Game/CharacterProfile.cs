using System.Collections.Generic;
public class CharacterProfile
{
   //PRIVATE:
    private readonly Dictionary<Character.Skill, SummProperty> skills;
    private List<IUserStory> story;

    //PUBLIC:
    public string name;
    public int age;

    public readonly Dictionary<Character.Belief, int> beliefs;

    public IProperty<int> this[Character.Skill key]
    {
        get
        {
            SummProperty skill = skills[key];
            if(skill != null)
            {
                skill = skills[key] = new SummProperty(0);
            }
            return skill;
        }
    }

}