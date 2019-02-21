using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC_MusicPlayer
{
    class Artist
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        private List<Song> performances;

        public IReadOnlyList<Song> Performances
        {
            get { return this.performances.AsReadOnly(); }
        }

        public Artist(string name, DateTime birthday)
        {
            performances = new List<Song>();
        }

        public void Add(Song song)
        {

        }

        public override string ToString()
        {
            //TODO: Make usefull return
            return base.ToString();
        }
    }
}
