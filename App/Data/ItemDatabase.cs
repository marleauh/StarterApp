using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using App.Models;

namespace App.Data
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;
        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            //Get all items.
            return database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(int id)
        {
            // Get a specific item.
            return database.Table<Item>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.Id != 0)
            {
                // Update an existing item.
                return database.UpdateAsync(item);
            }
            else
            {
                // Save a new item.
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            // Delete a item.
            return database.DeleteAsync(item);
        }
    }
}