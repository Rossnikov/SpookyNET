using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SpookyDISC.Services;

namespace SpookyDISC.Modules
{
    // Modules must be public and inherit from an IModuleBase
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        // Dependency Injection will fill this value in for us
        public PictureService PictureService { get; set; }
        public SpookyService SpookyService { get; set; }

        [Command("cat")]
        public async Task CatAsync()
        {
            // Get a stream containing an image of a cat
            var stream = await PictureService.GetCatPictureAsync();
            // Streams must be seeked to their beginning before being uploaded!
            stream.Seek(0, SeekOrigin.Begin);
            await Context.Channel.SendFileAsync(stream, "cat.png");
        }

        [Command("spookme")]
        public Task SpookyAsync()
            => ReplyAsync(SpookyService.GetSpookyDescription());

        [Command("saypoop")]
        public Task SayPoopAsync()
            => ReplyAsync("poop");
    }
}
