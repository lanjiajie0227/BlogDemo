using System;
using System.Collections.Generic;

namespace MyBlogApp.Entities
{
    /// <summary>
    /// 标签信息表
    /// </summary>
    public partial class Labelinfo
    {
        public string LabelId { get; set; } = null!;
        public string LabelName { get; set; } = null!;
    }
}
