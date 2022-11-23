namespace NewLanguages;

public class GenericAttribute<T> : Attribute
{
    public T Value { get; set; }
}

public class UseAttribute
{
    [GenericAttribute<string>()]
    public string Method() => default;
}