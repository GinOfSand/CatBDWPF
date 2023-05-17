using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatBDWPF
{
    internal class Family
    {
        
        public int Id { get; set; }
        public string FamylyName { get; set; }
        public Character character { get; set; }
        public BreedInformation information { get; set; }

        public override string ToString()
        {
            return $"{FamylyName}";
        }
    }
}
