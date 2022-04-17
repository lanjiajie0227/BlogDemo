using System;
using System.Collections.Generic;

namespace MyBlogApp.Entities
{
    /// <summary>
    /// 分类信息表
    /// </summary>
    public partial class Classifyinfo
    {
        public string ClassifyId { get; set; } = null!;
        public string ClassifyName { get; set; } = null!;
        public string? ParentClassifyId { get; set; }
    }
}
