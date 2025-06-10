using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightAI.Core.Pages
{
    public class GoogleHomePage
    {
        private readonly IPage _page;
        public GoogleHomePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task<string> GetTitleAsync()
        {
            return await _page.TitleAsync();
        }
    }
}
