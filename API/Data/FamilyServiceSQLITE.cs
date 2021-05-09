using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class FamilyServiceSQLITE: IFamilyService
    {
        private FamilyDBContext dbContext;
        public FamilyServiceSQLITE(FamilyDBContext familyDbContext)
        {
            dbContext = familyDbContext;
        }

        public async Task<IList<Family>> GetFamiliesOfUser(int userId)
        {
            var tmp = new List<Family>();
            IList<Family> AlLFamilies = await dbContext.Families.Include(a => a.Adults).Include(a=> a.Children).Include(a=> a.Pets).ToListAsync();
            
            foreach (var f in AlLFamilies)
            {
                if(f.UserId==userId) tmp.Add(f);
            }
            return tmp;
        }

        public async Task<IList<Family>> GetAllFamilies()
        {
            IList<Family> AlLFamilies = await dbContext.Families.Include(a => a.Adults).Include(a=> a.Children).Include(a=> a.Pets).ToListAsync();
            return AlLFamilies;
        }

        public async void AddFamily(Family family)
        {
            await dbContext.AddAsync(family);
            await dbContext.SaveChangesAsync();
        }

        
        public async void RemoveFamily(int familyId)
        {
            Family toRemove = await dbContext.Families.Include(a => a.Adults).Include(a=> a.Children).Include(a=> a.Pets).FirstAsync(f => f.Id == familyId); 
            Console.WriteLine(JsonSerializer.Serialize(toRemove));
             dbContext.Remove(toRemove);
            await dbContext.SaveChangesAsync();
        }

        public async void UpdateFamily(Family family)
        {
            Console.WriteLine("called");
            Family toUpdate = await dbContext.Families.FirstAsync(f => f.Id == family.Id);
            Console.WriteLine(JsonSerializer.Serialize(toUpdate));
            toUpdate.Adults = family.Adults.ToList();
            toUpdate.StreetName = family.StreetName;
            toUpdate.Children = family.Children.ToList();
            toUpdate.Pets = family.Pets.ToList();
            toUpdate.HouseNumber = family.HouseNumber;
            Console.WriteLine(JsonSerializer.Serialize(toUpdate));
            dbContext.Update(toUpdate);
            await dbContext.SaveChangesAsync();


        }
    }
}