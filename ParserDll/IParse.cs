using System.Threading.Tasks;
namespace ParserDll
{
    interface IParse
    {
        T Parse<T>() where T : new();

        Task<T> ParseAsync<T>() where T : new();

    }
}
