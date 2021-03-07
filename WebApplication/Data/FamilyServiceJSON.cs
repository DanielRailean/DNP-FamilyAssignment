using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace WebApplication.Data
{
    public class FamilyServiceJSON : IFamilyService
    {
        private IList<Family> AlLFamilies;
        private string familyFile = "families.json";

        public FamilyServiceJSON()
        {
            if (File.Exists(familyFile))
            {
                string serialized = File.ReadAllText(familyFile);
                AlLFamilies = JsonSerializer.Deserialize<IList<Family>>(serialized);
            }
            else
            {
                AlLFamilies = new List<Family>();
            }
        }

        private void Save()
        {
            string familyDone = JsonSerializer.Serialize(AlLFamilies);
            File.WriteAllText(familyFile,familyDone);   
        }

        public IList<Family> GetFamiliesOfUser(int userId)
        {
            List<Family> tmp = new List<Family>();
            foreach (var f in AlLFamilies)
            {
                if(f.UserId==userId) tmp.Add(f);
            }
            return tmp;
        }

        public IList<Family> GetAllFamilies()
        {
            List<Family> tmp = new List<Family>(AlLFamilies);
            return tmp;
        }

        public void AddFamily(Family family)
        {
            string streetComb = family.StreetName + family.HouseNumber;
            var temp = AlLFamilies.FirstOrDefault(f => (f.StreetName + f.HouseNumber).Equals(streetComb));
            if (temp == null)
            {
                int max = AlLFamilies.Max(f => f.Id);
                family.Id = (++max);
                AlLFamilies.Add(family);
                Save();     
            }
            else
            {
                throw new Exception("A family already lives on this street, in that house.");
            }
           
        }

        public void RemoveFamily(int familyId)
        {
            Family rm = AlLFamilies.First(f => f.Id == familyId);
            AlLFamilies.Remove(rm);
            Save();
        }

        public void UpdateFamily(Family family)
        {
            Family edit = AlLFamilies.First(f => f.Id == family.Id);
            edit.Adults = family.Adults;
            edit.Children = family.Children;
            edit.Pets = family.Pets;
            edit.HouseNumber = family.HouseNumber;
            edit.StreetName = family.StreetName;
            Save();
        }
    }
}