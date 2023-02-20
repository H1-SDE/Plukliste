namespace Plukliste;
public class Pluklist
{
    public string? Name;
    public string? Forsendelse;
    public string? Adresse;
    public List<Item> Lines = new List<Item>();
    public void AddItem(Item item) { Lines.Add(item); }
}

public class Item
{
    public string? ProductID { get; set; }
    public string? Title { get; set; }
    public ItemType Type { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
}

public enum ItemType
{
    Fysisk, Print, Pickup
}



