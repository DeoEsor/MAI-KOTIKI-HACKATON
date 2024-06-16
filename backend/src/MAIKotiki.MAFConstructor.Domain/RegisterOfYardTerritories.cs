using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RegisterOfYardTerritories
{
    public int IDOfTheParentObject { get; set; }

    public string District { get; set; }

    public string GRBS { get; set; }

    public string Region { get; set; }

    public string Name { get; set; }

    public string BalanceSheetHolder { get; set; }

    public float TotalArea { get; set; }
}