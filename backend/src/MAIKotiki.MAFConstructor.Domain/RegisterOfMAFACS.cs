namespace MAIKotiki.MAFConstructor.Domain;

public class RegisterOfMAFACS
{
    public int IDOfTheMAF { get; set; }

    public string TypeOfMAF { get; set; }

    public string NameOfTheParentObject { get; set; }

    public string IDOfTheParentObject { get; set; }

    public string DistrictOfTheParentObject { get; set; }

    public string BalanceHolderOfParentObject { get; set; }

    public string GRBS { get; set; }

    public string ElementBelongsToTheTerritoryZone { get; set; }
}