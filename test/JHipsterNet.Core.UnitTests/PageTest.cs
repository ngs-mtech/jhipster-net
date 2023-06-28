using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using Xunit;

namespace JHipsterNet.Core.UnitTests
{
    public class PageTest
    {
        [Fact]
        public void TestPageCountCornerCases()
        {
            int pageSize = 4;
            Pageable pageable = Pageable.Of(0, pageSize, null);

            int totalElements = 0;

            // test empty results is a just one page result.
            Page<string> page = new Page<string>(new List<String>(), pageable, totalElements);
            Assert.Equal(0, page.TotalPages);

            List<String> items = new List<String> { "a", "b", "c", "d" };

            totalElements = 4;
            // test a single full page
            page = new Page<string>(items, pageable, totalElements);

            Assert.Equal( 1, page.TotalPages);

            totalElements = 5;
            // test two pages result
            page = new Page<string>(items, pageable, totalElements);

            Assert.Equal( 2, page.TotalPages);

            totalElements = 7;
            // test two pages result
            page = new Page<string>(items, pageable, totalElements);

            Assert.Equal(2, page.TotalPages);

            totalElements = 8;
            // test two full pages result
            page = new Page<string>(items, pageable, totalElements);

            Assert.Equal(2, page.TotalPages);

            totalElements = 9;
            // test three pages result
            page = new Page<string>(items, pageable, totalElements);

            Assert.Equal(3, page.TotalPages);
        }
    }
}
