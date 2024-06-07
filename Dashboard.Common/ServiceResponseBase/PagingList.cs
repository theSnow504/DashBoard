
namespace Dashboard.Common
{
    public class PagingList<T>
    {
        public PagingList()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Cái này để web hiển thị có tổng số bao nhiêu bản ghi, tổng số page là bao nhiêu, hiện tại đang ở số page số mấy

        /// </summary>
        public Metadata MetaData { get; set; }

        /// <summary>
        /// List của page hiện tại
        /// </summary>
        public List<T> Items { get; set; }
    }
}
