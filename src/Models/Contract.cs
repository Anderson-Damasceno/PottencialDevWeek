namespace src.Models;

public class Contract
{
    public Contract()
    {
        TokenId = "000000";
        Value = 0;
        Paid = false;
        CreationDate = DateTime.Now;
    }

    public Contract(string tokenId, double value, bool paid = false)
    {
        TokenId = tokenId;
        Value = value;
        Paid = paid;
        CreationDate = DateTime.Now;
    }
    public string? TokenId {get; set;}
    public double Value {get;set;}
    public bool Paid {get; set;}
    public DateTime CreationDate {get; set;}

}