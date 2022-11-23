
public class DamageRelations
{
    public List<DoubleDamageFrom> double_damage_from { get; set; }
    public List<DoubleDamageTo> double_damage_to { get; set; }
    public List<HalfDamageFrom> half_damage_from { get; set; }
    public List<HalfDamageTo> half_damage_to { get; set; }
    public List<NoDamageFrom> no_damage_from { get; set; }
    public List<NoDamageTo> no_damage_to { get; set; }
}

public class DoubleDamageFrom
{
    public string name { get; set; }
    public string url { get; set; }
}

public class DoubleDamageTo
{
    public string name { get; set; }
    public string url { get; set; }
}

public class GameIndex
{
    public int game_index { get; set; }
    public Generation generation { get; set; }
}

public class Generation
{
    public string name { get; set; }
    public string url { get; set; }
}

public class HalfDamageFrom
{
    public string name { get; set; }
    public string url { get; set; }
}

public class HalfDamageTo
{
    public string name { get; set; }
    public string url { get; set; }
}

public class NoDamageFrom
{
    public string name { get; set; }
    public string url { get; set; }
}

public class NoDamageTo
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Language
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Move
{
    public string name { get; set; }
    public string url { get; set; }
}

public class MoveDamageClass
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Name
{
    public Language language { get; set; }
    public string name { get; set; }
}

public class PastDamageRelation
{
    public DamageRelations damage_relations { get; set; }
    public Generation generation { get; set; }
}

public class Pokemon
{
    public Pokemon pokemon { get; set; }
    public int slot { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}

public class Root
{
    public DamageRelations damage_relations { get; set; }
    public List<GameIndex> game_indices { get; set; }
    public Generation generation { get; set; }
    public int id { get; set; }
    public MoveDamageClass move_damage_class { get; set; }
    public List<Move> moves { get; set; }
    public string name { get; set; }
    public List<Name> names { get; set; }
    public List<PastDamageRelation> past_damage_relations { get; set; }
    public List<Pokemon> pokemon { get; set; }
}

