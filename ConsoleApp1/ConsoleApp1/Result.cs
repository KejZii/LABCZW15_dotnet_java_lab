namespace ConsoleApp1;

public class Result
{
    public List<int> itemsInSuc = new List<int>();
    public int valueSum;
    public int wageSum;

    public override string ToString()
    {
        string returnString = "";
        returnString = "Items in the backpack: \n";
        returnString = "Item no.: ";
        foreach (var id in itemsInSuc)
        {
            returnString += $"{id}, ";
        }
        Console.WriteLine($"Total value: {valueSum}");
        Console.WriteLine($"Total weight: {wageSum}");
        return returnString;
    }
}