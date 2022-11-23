
using System.Linq;

public class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient client = new();

        Console.WriteLine("Enter Pokemon name: ");

        var typeName =  Console.ReadLine();

        if(string.IsNullOrEmpty(typeName))
        {
            Console.WriteLine("Name is empty");
        }
        else
        {
            typeName = typeName.Trim().ToLower();
            await GetStrengthsAndWeaknesses(client, typeName);
        }  
       

        async Task GetStrengthsAndWeaknesses(HttpClient client, string name)
        { 
            try
            {
                var json = await client.GetStringAsync("https://pokeapi.co/api/v2/type/" + name);

                var root = GetRoot(json);

                if (root != null && root.damage_relations != null)
                {
                    DsiplayStrengthsAndWeaknesses(root.damage_relations, root.name.ToUpper());
                }
                else
                {
                    Console.WriteLine("The entered type is wrong.");
                }
            } 
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            
        }

        void DsiplayStrengthsAndWeaknesses(DamageRelations damageRelations, string typeName)
        {
            DisplayStrengths(damageRelations, typeName);

            DisplayWeaknesses(damageRelations, typeName);
        }
    } 

    private static void DisplayWeaknesses(DamageRelations damageRelations, string typeName)
    {
        if (damageRelations.double_damage_from.Count > 0 || damageRelations.no_damage_to.Count > 0)
        {
            Console.WriteLine($"The following are the Weaknesses of type:{typeName}");
            if (damageRelations.double_damage_from.Count > 0)
            {
                foreach (var weakness in damageRelations.double_damage_from)
                {
                    Console.WriteLine(weakness.name.ToUpper());
                }
            }
            if (damageRelations.no_damage_to.Count > 0)
            {               
                foreach (var weakness in damageRelations.no_damage_to)
                {
                    Console.WriteLine(weakness.name.ToUpper());
                }
            }
        }
        else
        {
            Console.WriteLine($"No Weaknesses Found for type: {typeName}");
        }
    }

    private static void DisplayStrengths(DamageRelations damageRelations, string typeName)
    {
        if (damageRelations.double_damage_to.Count > 0 || damageRelations.no_damage_from.Count > 0)
        {
            Console.WriteLine($"The following are the Strengths of type:{typeName}");
            if(damageRelations.double_damage_to.Count > 0)
            {
                foreach (var strength in damageRelations.double_damage_to)
                {
                    Console.WriteLine(strength.name.ToUpper());
                }
            }
           if (damageRelations.no_damage_from.Count > 0)
            {
                foreach (var strength in damageRelations.no_damage_from)
                {
                    Console.WriteLine(strength.name.ToUpper());
                }
            } 
        }
        else
        {
            Console.WriteLine($"No Strengths Found for the type: {typeName}");
        }
    } 
    private static Root? GetRoot(string json)
    {
        return System.Text.Json.JsonSerializer.Deserialize<Root>(json);
    }
}