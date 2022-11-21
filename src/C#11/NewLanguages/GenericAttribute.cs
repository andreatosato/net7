namespace NewLanguages;

public class GenericAttribute<T> : Attribute
{

}

public class UseAttribute
{
    [GenericAttribute<string>()]
    public string Method() => default;
}