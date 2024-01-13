using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Commons.Common_Page
{
    public class PageResult<T>
    {
        public Pagination pagination { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PageResult(Pagination pagination, IEnumerable<T> data)
        {
            this.pagination = pagination;
            Data = data;
        }
        public static IEnumerable<T> ToPageResult(Pagination pagination, IEnumerable<T> data)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;
            data = data.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
            return data;
        }
    }
}
