using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZeroC.Entities.XML
{
	[XmlRoot(ElementName = "rss", Namespace = "")]
	public class TagPage
	{
		[XmlElement(ElementName = "channel", Namespace = "")]
		public Channel ChannelField { get; set; }

		[XmlAttribute(AttributeName = "version", Namespace = "")]
		public double Version { get; set; }

		[XmlAttribute(AttributeName = "media", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Media { get; set; }

		[XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Atom { get; set; }

		[XmlText]
		public string Text { get; set; }


		[XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
		public class Link
		{

			[XmlAttribute(AttributeName = "href", Namespace = "")]
			public string Href { get; set; }

			[XmlAttribute(AttributeName = "rel", Namespace = "")]
			public string Rel { get; set; }

			[XmlAttribute(AttributeName = "type", Namespace = "")]
			public string Type { get; set; }
		}

		[XmlRoot(ElementName = "summary", Namespace = "")]
		public class Summary
		{

			[XmlAttribute(AttributeName = "type", Namespace = "")]
			public string Type { get; set; }

			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
		public class Thumbnail
		{

			[XmlAttribute(AttributeName = "url", Namespace = "")]
			public string Url { get; set; }
		}

		[XmlRoot(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
		public class Content
		{

			[XmlAttribute(AttributeName = "url", Namespace = "")]
			public string Url { get; set; }

			[XmlAttribute(AttributeName = "width", Namespace = "")]
			public int Width { get; set; }

			[XmlAttribute(AttributeName = "height", Namespace = "")]
			public int Height { get; set; }

			[XmlAttribute(AttributeName = "expression", Namespace = "")]
			public string Expression { get; set; }
		}

		[XmlRoot(ElementName = "item", Namespace = "")]
		public class Item
		{

			[XmlElement(ElementName = "title", Namespace = "")]
			public List<string> Title { get; set; } = new List<string>();

			[XmlElement(ElementName = "link", Namespace = "")]
			public string Link { get; set; }

			[XmlElement(ElementName = "summary", Namespace = "")]
			public Summary Summary { get; set; }

			[XmlElement(ElementName = "guid", Namespace = "")]
			public string Guid { get; set; }

			[XmlElement(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
			public Thumbnail Thumbnail { get; set; }

			[XmlElement(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
			public Content Content { get; set; }

			[XmlElement(ElementName = "keywords", Namespace = "http://search.yahoo.com/mrss/")]
			public string Keywords { get; set; }

			[XmlElement(ElementName = "rating", Namespace = "http://search.yahoo.com/mrss/")]
			public string Rating { get; set; }
		}

		[XmlRoot(ElementName = "channel", Namespace = "")]
		public class Channel
		{

			[XmlElement(ElementName = "title", Namespace = "")]
			public string Title { get; set; }

			[XmlElement(ElementName = "link", Namespace = "")]
			public List<string> Link { get; set; } = new List<string>();

			[XmlElement(ElementName = "description", Namespace = "")]
			public string Description { get; set; }

			[XmlElement(ElementName = "item", Namespace = "")]
			public List<Item> Item { get; set; } = new List<Item>();
		}
	}
}
