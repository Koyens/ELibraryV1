using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary2.models
{
    public class bookInventoryModels
    {
        public string bookID { get; set; }
        public string bookName { get; set; }
        public string language { get; set; }
        public string publisherName { get; set; }
        public string authorName { get; set; }
        public string publisDate { get; set; }
        public string genre { get; set; }
        public string edition { get; set; }
        public string bookCost { get; set; }
        public string pagesNo { get; set; }
        public string actualStock { get; set; }
        public string currentStock { get; set; }
        public string bookDescription { get; set; }
        public string bookLink { get; set; }
    }
}