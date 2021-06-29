using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZeroC.Enums;

namespace ZeroC.Entities
{
    public class TagPage
    {
        private readonly HttpClient _parentClient;

        public string Tag { get; }
        public ZCImage HeaderImage { get; internal set; }
        public IEnumerable<Tag> HeaderTags { get; internal set; }
        public string Description { get; internal set; }

        internal TagPage(HttpClient parentClient, string tag)
        {
            this._parentClient = parentClient;
            this.Tag = tag;
        }

        internal async ValueTask LoadDataAsync()
        {
            var pageData = await this._parentClient.GetStringAsync($"https://www.zerochan.net/{HttpUtility.UrlEncode(Tag)}");
            var doc = new HtmlDocument();
            doc.LoadHtml(pageData);
            var headerImageId = await this.GetHeaderImageIdAsync(doc);
            var headerImageJson = await this._parentClient.GetStringAsync($"https://www.zerochan.net{headerImageId}?json");
            HeaderImage = JsonConvert.DeserializeObject<ZCImage>(headerImageJson);
            HeaderTags = this.GetHeaderImageTags(doc);
            Description = await this.GetHeaderDescriptionAsync(doc);
        }

        private ValueTask<string> GetHeaderImageIdAsync(HtmlDocument page)
        {
            string headerImageId = "";
            var node = page.DocumentNode.SelectSingleNode("//*[@id=\"menu\"]/p[1]/a");

            if (node != null)
                headerImageId = node.GetAttributeValue("href", null);
            else
            {
                node = page.DocumentNode.SelectSingleNode("//*[@id=\"menu\"]/p[1]/img");
                var srcArrtibute = node.GetAttributeValue("src", null);
                var srcAttributeParts = srcArrtibute.Split('.', StringSplitOptions.RemoveEmptyEntries);
                headerImageId = $"/{srcAttributeParts[srcAttributeParts.Length - 2]}";
            }
            return ValueTask.FromResult(headerImageId);
        }

        private IEnumerable<Tag> GetHeaderImageTags(HtmlDocument page)
        {
            var tagsTable = page.DocumentNode.SelectSingleNode("//*[@id=\"tags\"]");
            foreach (var tag in tagsTable.ChildNodes.Where(x => x.Name == "li"))
            {
                var theme = tag.GetAttributeValue("class", null);
                var tagName = tag.LastChild.InnerText;
                yield return new Tag(tagName, Enum.GetValues<TagType>().First(x => x.ToString().ToLower() == theme), null);
            }
        }

        private ValueTask<string> GetHeaderDescriptionAsync(HtmlDocument page)
        {
            var node = page.DocumentNode.SelectSingleNode("//*[@id=\"description\"]/p[1]");
            return ValueTask.FromResult(node?.InnerText);
        }
    }
}
