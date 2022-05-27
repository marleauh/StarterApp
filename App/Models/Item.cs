using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // You can change these variables and add more!
        public string ItemName { get; set; }
        public int ItemNumber { get; set; }
        public double ItemPrice { get; set; }
    }
}
