using HelpUp.Shared.ValueObject;
namespace HelpUp.Domain.ValueObjects;

public class Description : ValueObject
{
    public Description(string desc)
    {
        Desc = desc;
    }

    public string Desc { get; private set; }

    public override string ToString()
    {
        return Desc;
    }
}