using App3.Models;
using SQLite;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace App3.Data
{
    public class CharacterDatabase
    {
        readonly SQLiteAsyncConnection database;
        private readonly AsyncLock _asyncLock = new AsyncLock();

        public CharacterDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Character>().Wait();
            database.CreateTableAsync<Spell>().Wait();
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                return await database.Table<Character>().ToListAsync();
            }
        }

        public Task<List<Spell>> GetSpellsAsync() {  return database.Table<Spell>().ToListAsync();}

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            using (await _asyncLock.LockAsync())
            {
                return await database.Table<Character>().Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<Spell> GetSpellByIdAsync(int id)
        {
            using (await _asyncLock.LockAsync())
            {
                return await database.Table<Spell>().Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<int> SaveCharacterAsync(Character character)
        {
            using (await _asyncLock.LockAsync())
            {
                if (character.Id != 0)
                {
                    return await database.UpdateAsync(character);
                }
                else
                {
                    return await database.InsertAsync(character);
                }
            }
        }

        public async Task<int> SaveSpellAsync(Spell spell)
        {
            using (await _asyncLock.LockAsync())
            {
                if (spell.Id != 0)
                {
                    return await database.UpdateAsync(spell);
                }
                else
                {
                    return await database.InsertAsync(spell);
                }
            }
        }

        public async Task DeleteCharacterAsync(Character character)
        {
            using (await _asyncLock.LockAsync())
            {
                await database.DeleteAsync(character);
            }
        }

        public async Task DeleteSpellAsync(Spell spell)
        {
            using (await _asyncLock.LockAsync())
            {
                await database.DeleteAsync(spell);
            }
        }
    }
}
