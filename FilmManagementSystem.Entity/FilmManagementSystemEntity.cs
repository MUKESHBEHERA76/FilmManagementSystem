using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagementSystem.Entity
{
    [Serializable]
    public class FilmManagementSystemEntity
    {
        public string FilmTittle { get; set; }
        public string FilmActor { get; set; }
        public string FilmCategory { get; set; }
        public string FilmLanguage { get; set; }
        public string FilmDescription { get; set; }
        public int FilmReleaseYear { get; set; }
        public double FilmRentalDuration { get; set; }
        public double FilmRentalRate { get; set; }
        public double FilmLength { get; set; }
        public double FilmReplacementCost { get; set; }
        public double FilmRating { get; set; }
    }
}
