using MyBlogApp.Entities;

namespace MyBlogApp.Data
{
    public class ClassifyInfoService
    {
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Task<bool> SaveClassifyInfoAsync(Classifyinfo info)
        {
            using (var context = new myblogsContext())
            {
                context.Classifyinfos.Add(info);
                context.SaveChanges();
            }
            return Task.FromResult(true);
        }
        /// <summary>
        /// 获取所以分类
        /// </summary>
        /// <returns></returns>
        public Task<Classifyinfo[]> GetAllClassifyInfoAsync()
        {
            Classifyinfo[] classifyinfos;
            using (var context = new myblogsContext())
            {
                classifyinfos = context.Classifyinfos.ToArray();
            }
            return Task.FromResult(classifyinfos);
        }
        /// <summary>
        /// 删除指定分类
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Task<bool> DeleteClassifyById(Classifyinfo info)
        {
            using (var context = new myblogsContext())
            {
                context.Classifyinfos.Remove(info);
                context.SaveChanges();
            }
            return Task.FromResult(true);
        }
    }
}
