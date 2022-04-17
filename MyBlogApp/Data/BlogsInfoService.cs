using MyBlogApp.Entities;

namespace MyBlogApp.Data
{
    public class BlogsInfoService
    {
        /// <summary>
        /// 添加博文数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SaveBlogInfo(Blogsinfo info)
        {
            using (var context = new myblogsContext())
            {
                context.Blogsinfos.Add(info);
                context.SaveChanges();  //保存更改
            }
            return true;
        }

        /// <summary>
        /// 获取全部博文
        /// </summary>
        /// <returns></returns>
        public Task<Blogsinfo[]> GetAllBlogInfoAsync()
        {
            Blogsinfo[] blogsinfos;
            using (var context = new myblogsContext())
            {
                blogsinfos = context.Blogsinfos.ToArray();
            }

            return Task.FromResult(blogsinfos);
        }
        /// <summary>
        /// 获取单条博文数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Blogsinfo> GetBlogInfoByIdAsync(string id)
        {
            Blogsinfo bloginfo;
            using (var context = new myblogsContext())
            {
                bloginfo = context.Blogsinfos.Single(b => b.BlogId == id);
            }
            return Task.FromResult(bloginfo);
        }
    }
}
