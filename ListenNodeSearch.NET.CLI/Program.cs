using System;
using System.Threading.Tasks;
using ListenNotesSearch.NET;
using Type = ListenNotesSearch.NET.Models.Type;

namespace ListenNodeSearch.NET.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new ListenNodeSearchClient("dad39050909646f9a6976c88fec19a01");
            var result = await service.SearchAsync("el transistor", 1, Type.Podcast);
        }
    }
}
