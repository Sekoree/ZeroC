using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZeroC.Entities;
using ZeroC.Enums;

namespace ZeroC
{
    public class ZeroChanClient
    {
        private readonly HttpClient _httpClient;
        public bool _loggedIn { get; internal set; } = false;

        public ZeroChanClient()
        {
            _httpClient = new HttpClient();
        }

        public ZeroChanClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async ValueTask<ZeroChanClient> LoginAsync(string username, string password)
        {
            using (var content = new StringContent($"ref=%2F&name={username}&password={password}&login=Login", Encoding.UTF8, "application/x-www-form-urlencoded"))
            using (var msg = new HttpRequestMessage(HttpMethod.Post, "https://www.zerochan.net/login"))
            {
                msg.Content = content;
                var resp = await this._httpClient.SendAsync(msg);
                if (resp.IsSuccessStatusCode)
                {
                    this._loggedIn = true;
                    return this;
                }
            }
            return default;
        }

        public async ValueTask<ZeroChanClient> LogoutAsync()
        {
            if (!_loggedIn)
                return default;
            var resp = await this._httpClient.GetAsync("https://www.zerochan.net/logout", HttpCompletionOption.ResponseHeadersRead);
            if (resp.IsSuccessStatusCode)
            {
                this._loggedIn = false;
                return this;
            }
            return default;
        }

        public async ValueTask<IEnumerable<Tag>> GetSuggestionResultsAsync(string input)
        {
            var tags = await this._httpClient.GetStringAsync($"https://www.zerochan.net/suggest?q={HttpUtility.UrlEncode(input)}");
            var tagsArray = tags.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            List<Tag> suggestions = new();
            foreach (var tagItem in tagsArray)
            {
                var tagParts = tagItem.Split("|");
                suggestions.Add(new Tag(tagParts[0], Enum.GetValues<TagType>().First(x => x.ToString() == tagParts[1]), tagParts[2]));
            }
            return suggestions;
        }

        public async ValueTask<object> GetTagPageAsync(string tag)
        {
            var tp = new TagPage(this._httpClient, tag);
            await tp.LoadDataAsync();
            return default;
        }
    }
}
