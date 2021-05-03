using System;
using System.Threading.Tasks;
using Module_4_Task_6.Services;

namespace Module_4_Task_6
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                var songService = new SongService(context);
                await songService.GetSongsByGenre();
            }
        }
    }
}
