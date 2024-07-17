using App3.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App3.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;
        private readonly AsyncLock _asyncLock = new AsyncLock();

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                return await database.Table<Note>().ToListAsync();
            }
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            using (await _asyncLock.LockAsync())
            {
                return await database.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
            }
        }

        public async Task<int> SaveNoteAsync(Note note)
        {
            using (await _asyncLock.LockAsync())
            {
                if (note.ID != 0)
                {
                    return await database.UpdateAsync(note);
                }
                else
                {
                    return await database.InsertAsync(note);
                }
            }
        }

        public async Task DeleteNoteAsync(Note note) {
            using (await _asyncLock.LockAsync())
            {
               await database.DeleteAsync(note);
            }
        }
    }
}
