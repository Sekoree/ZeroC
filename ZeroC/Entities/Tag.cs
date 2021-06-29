using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroC.Enums;

namespace ZeroC.Entities
{
    public struct Tag
    {
        public string TagName { get; }
        public TagType Category { get; }
        public string Parent { get; }

        internal Tag(string tagName, TagType category, string parent)
        {
            this.TagName = tagName;
            this.Category = category;
            this.Parent = parent;
        }
    }
}
