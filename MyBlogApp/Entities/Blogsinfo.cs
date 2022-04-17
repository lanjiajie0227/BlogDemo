using System;
using System.Collections.Generic;

namespace MyBlogApp.Entities
{
    /// <summary>
    /// 博文信息表
    /// </summary>
    public partial class Blogsinfo
    {
        public string BlogId { get; set; } = null!;
        public string BlogTitle { get; set; } = null!;
        public string BlogRichText { get; set; } = null!;
        public string Creater { get; set; } = null!;
        public DateTime CreateTime { get; set; }
        public string Classify { get; set; } = null!;
        public string Label { get; set; } = null!;
        public int SumText { get; set; }
    }
}
