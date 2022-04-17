using MyBlogApp.Entities;

namespace MyBlogApp.Data
{
    public class LabelInfoService
    {
        /// <summary>
        /// 保存标签数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Task<bool> SaveLabelInfoAsync(Labelinfo info)
        {
            using (var context = new myblogsContext())
            {
                context.Labelinfos.Add(info);
                context.SaveChanges();
            }
            return Task.FromResult(true);
        }
        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <returns></returns>
        public Task<Labelinfo[]> GetAllLabelInfoAsync()
        {
            Labelinfo[] labelinfos;
            using (var context = new myblogsContext())
            {
                labelinfos = context.Labelinfos.ToArray();
            }
            return Task.FromResult(labelinfos);
        }
        /// <summary>
        /// 删除指定标签
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Task<bool> DeleteLabelInfoById(Labelinfo info)
        {
            using (var context = new myblogsContext())
            {
                context.Labelinfos.Remove(info);
                context.SaveChanges();
            }
            return Task.FromResult(true);
        }
    }
}
