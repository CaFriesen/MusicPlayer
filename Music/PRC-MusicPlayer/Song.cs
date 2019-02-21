using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC_MusicPlayer
{
    class Song
    {
        public string Name { get; private set; }
        public int Year { get; private set; }
        public string PathToFile { get; private set; }
        public string Lyrics { get; private set; }
        public Artist Performer { get; private set; }

        public Song(string name, int year, Artist performer, string pathToFile)
        {
            Name = name;
            Year = year;
            Performer = performer;
            PathToFile = pathToFile;
        }

        public override string ToString()
        {
            //TODO: Make usefull
            return base.ToString();
        }
    }
}
