namespace ParserDll
{
    interface IParse
    {
        T Parse<T>() where T : new();
    }
}
