using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CatBDWPF.Serves
{
    internal class ApplicationDbServes
    {
        public bool AddFamily
            (
            string familyname,
            //BreedInfo
            string country,
            string lifeExpectancy,
            string size,
            double weight,
            string coatType,
            string color,
            string lifestyle,
            string group,
            string price,
            //Character
            int adaptabiliti,
            int attachmentTofamily,
            int gameActivity,
            int intelligence,
            int generalHealth,
            int hairLoss, 
            int friendlinessForChildre,
            int friendlyToDogs,
            int loveForMeow
            )

        {
            if(
                adaptabiliti           <= 10 &&
                attachmentTofamily     <= 10 &&
                gameActivity           <= 10 &&
                intelligence           <= 10 &&
                generalHealth          <= 10 &&
                hairLoss               <= 10 &&
                friendlinessForChildre <= 10 &&
                friendlyToDogs         <= 10 &&
                loveForMeow            <= 10
                ) {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    Family famylys = db.Families.FirstOrDefault(f => f.FamylyName == familyname);
                    if (famylys == null)
                    {
                        Family breed = new Family() { FamylyName = familyname };
                        db.Families.Add(breed);
                        BreedInformation inf = new BreedInformation()
                        {
                            CountryOfOrigin = country,
                            LifeExpectancy = lifeExpectancy,
                            Size = size,
                            Weight_kg = weight,
                            CoatType = coatType,
                            Color = color,
                            Lifestyle = lifestyle,
                            Group = group,
                            Price = price,
                            famyly = breed,
                            FamylyId = breed.Id
                        };
                        db.BreedInformation.Add(inf);

                        Character bc = new Character()
                        {
                            Adaptabiliti = adaptabiliti,
                            AttachmentTofamily = attachmentTofamily,
                            GameActivity = gameActivity,
                            Intelligence = intelligence,
                            GeneralHealth = generalHealth,
                            HairLoss = hairLoss,
                            FriendlinessForChildren = friendlinessForChildre,
                            FriendlyToDogs = friendlyToDogs,
                            LoveForMeow = loveForMeow,
                            famyly = breed,
                            FamylyId = breed.Id
                            

                        };
                        db.Characters.Add(bc);
                        db.SaveChanges();
                        db.Database.Connection.Close();
                        return true;
                    }
                    else
                    {
                        db.Database.Connection.Close();
                        return false;
                    }
                    
                }

            }else
                throw new Exception("В строки харрактеристик введены не числа или они больше 10");

        }
        public bool DeleteFamily(string family)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Family f = db.Families.FirstOrDefault(fa=>fa.FamylyName == family);
                if (f != null)
                {
                    BreedInformation breed = db.BreedInformation.FirstOrDefault(fi => fi.famyly.Id == f.Id);
                    Character charac = db.Characters.FirstOrDefault(fc => fc.famyly.Id == f.Id);
                    db.BreedInformation.Remove(breed); 
                    db.Characters.Remove(charac);
                    db.Families.Remove(f);
                    db.SaveChanges();
                    db.Database.Connection.Close();
                    return true;
                }
                else
                {
                    db.Database.Connection.Close();
                    return false;
                }
            }
            
        }
        public bool RedactionFamily
            (
            string familyname,
            //BreedInfo
            string country,
            string lifeExpectancy,
            string size,
            double weight,
            string coatType,
            string color,
            string lifestyle,
            string group,
            string price,
            //Character
            int adaptabiliti,
            int attachmentTofamily,
            int gameActivity,
            int intelligence,
            int generalHealth,
            int hairLoss,
            int friendlinessForChildre,
            int friendlyToDogs,
            int loveForMeow
            )
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                Family famylys = db.Families.FirstOrDefault(f => f.FamylyName == familyname);
                if (famylys != null)
                {


                    BreedInformation inf = db.BreedInformation.FirstOrDefault(i => i.famyly.Id == famylys.Id);
                    if (inf != null)
                    {
                        inf.CountryOfOrigin = country;
                        inf.LifeExpectancy = lifeExpectancy;
                        inf.Size = size;
                        inf.Weight_kg = weight;
                        inf.CoatType = coatType;
                        inf.Color = color;
                        inf.Lifestyle = lifestyle;
                        inf.Group = group;
                        inf.Price = price;

                    };


                    Character ch = db.Characters.FirstOrDefault(i => i.famyly.Id == famylys.Id);
                    {
                        ch.Adaptabiliti = adaptabiliti;
                        ch.AttachmentTofamily = attachmentTofamily;
                        ch.GameActivity = gameActivity;
                        ch.Intelligence = intelligence;
                        ch.GeneralHealth = generalHealth;
                        ch.HairLoss = hairLoss;
                        ch.FriendlinessForChildren = friendlinessForChildre;
                        ch.FriendlyToDogs = friendlyToDogs;
                        ch.LoveForMeow = loveForMeow;

                    };


                    db.SaveChanges();
                    db.Database.Connection.Close();
                    return true;
                }
                else
                {
                    db.Database.Connection.Close();
                    return false;
                }
            }
        }
        public Family SeeFaSelect(string fName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Family family = db.Families.FirstOrDefault(f=>f.FamylyName == fName);
                return family;
            }
        }
    }
}
