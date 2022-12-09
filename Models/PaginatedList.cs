using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCh12.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }      //property
        public int TotalPages { get; set; }     //property

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)  //constructor receiving items, count, pageindex, page size
        {
            PageIndex = pageIndex;                                                  
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);               //calculating number of pages based on the size

            this.AddRange(items);
        }

        public bool HasPreviousPage                                                 //determines whether there is a previous or next page
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        //Async method retreives a count of the pages
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            //skips over pages that will not be displayed at that moment
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(); 
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

    }
}
