using System;
using System.Collections.Generic;

namespace PaginationHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Page");
            var helper = new PaginationHelper<char>(new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' }, 4);
            Console.WriteLine($"{helper.PageCount}"); //should == 2
            Console.WriteLine($"{helper.ItemCount}"); //should == 6
            Console.WriteLine(helper.PageItemCount(0)); //should == 4
            Console.WriteLine(helper.PageItemCount(1)); // last page - should == 2
            Console.WriteLine(helper.PageItemCount(2));// should == -1 since the page is invalid

        }
    }
    public class PaginationHelper<T>
    {
        // TODO: Complete this class

        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PaginationHelper(IList<T> collection, int itemsPerPage)
        {
            this.ItemsPerPage = itemsPerPage;
            this.ItemCount = collection.Count;
            if (collection.Count % itemsPerPage > 0)
            {
                this.PageCount = collection.Count / itemsPerPage + 1;
            }
            else
            {
                this.PageCount = collection.Count / itemsPerPage;
            }

        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemsPerPage { get; set; }
        public int ItemCount { get; set; }

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {

            if (pageIndex > -1 && pageIndex + 1 < this.PageCount)
            {
                return this.ItemsPerPage;
            }
            else if (pageIndex + 1 == this.PageCount)
            {
                if (this.ItemCount % this.ItemsPerPage > 0)
                {
                    return this.ItemCount % this.ItemsPerPage;
                }
                else
                {
                    return this.ItemsPerPage;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            if (itemIndex < this.ItemCount && itemIndex > -1)
            {
                return itemIndex / this.ItemsPerPage;
            }
            else
            {
                return -1;
            }

        }
    }
}
