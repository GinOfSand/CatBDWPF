using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatBDWPF
{
    internal class Character
    {
        public int Id { get; set; }


        // all characterisitc 10 ballov max
        public int Adaptabiliti { get; set; }
        public int AttachmentTofamily { get; set; }
        public int GameActivity { get; set; }
        public int Intelligence { get; set; }
        public int GeneralHealth { get; set; }
        public int HairLoss { get; set; }
        public int FriendlinessForChildren { get; set; }
        public int FriendlyToDogs { get; set; }
        public int LoveForMeow { get; set; }
        public int FamylyId { get; set; }
        [Required]
        public Family famyly { get; set; }
        public override string ToString()
        {
            return
                $"Id:{Id}\n" +
                $"Адаптируемость:{Adaptabiliti}/10\n" +
                $"Привязанность к семье:{AttachmentTofamily}/10\n" +
                $"Игровая активность:{GameActivity}/10\n" +
                $"Интелект:{Intelligence}/10\n" +
                $"Общее здоровье:{GeneralHealth}/10\n" +
                $"Выпадение шерсти:{HairLoss}/10\n" +
                $"Дружилюбность к детям:{FriendlinessForChildren}/10\n" +
                $"Дружилюбность к собакам:{FriendlyToDogs}/10\n" +
                $"Любовь к мяуканью:{LoveForMeow}/10\n"
                ;
        }
    }
}
