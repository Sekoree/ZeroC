using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroC.Enums
{
    /// <summary>
    /// Parameter s
    /// </summary>
    public enum SortOrder
    {
        //id
        [Description("s=id")]
        Recent,
        //fav
        [Description("s=fav")]
        Popular,
        //random
        [Description("s=random")]
        Random
    }

    /// <summary>
    /// Parameter t
    /// </summary>
    public enum PopularTimeframe
    {
        //0
        [Description("t=0")]
        AllTime,
        //2
        [Description("t=2")]
        ThreeMonths,
        //1
        [Description("t=1")]
        LastWeek
    }

    /// <summary>
    /// Parameter d
    /// </summary>
    public enum SizeFilter
    {
        //0
        [Description("d=0")]
        AllSizes,
        //1
        [Description("d=1")]
        LargeAndBetter,
        //2
        [Description("d=2")]
        OnlyVeryLarge
    }

    /// <summary>
    /// Either by pagenumber or last image Id
    /// </summary>
    public enum SearchMode
    {
        //p=Pagenumber
        [Description("p=")]
        PageNumber,
        //o=0 -> FirstPage
        //o=LastImageId -> Get the images after the one's specified ID
        [Description("o=")]
        ImageId
    }

    /// <summary>
    /// Tag type, potentially missing some.
    /// Not as string cause ZeroChan seems to care enough about them that they have their own icons
    /// </summary>
    public enum TagType
    {
        Meta,
        Theme,
        Series,
        Mangaka,
        Game,
        Character,
        Source
    }
}
