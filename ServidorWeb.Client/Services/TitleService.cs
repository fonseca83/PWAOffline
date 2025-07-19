using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ServidorWeb.Client.Services
{


    public class TitleService
    {
        private readonly IJSRuntime _js;

        public TitleService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetTitle(string title)
        {
            await _js.InvokeVoidAsync("setTitle", title);
        }
    }


}
