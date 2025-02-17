using System;
using System.Collections.Generic;

namespace JHipsterNet.Core.Pagination {
    public class Page<T> : Chunk<T>, IPage<T> where T : class {
        public Page(List<T> content, IPageable pageable, int total) : base(content, pageable)
        {
            Total = total;
        }

        public int Total { get; }

        public override bool HasNext => Number + 1 < TotalPages;

        public new bool IsLast => !HasNext;

        public int TotalPages => Size == 0 ? 1 : Convert.ToInt32( Math.Ceiling( (double) Total / Size) );

        public int TotalElements => Total;
    }
}
