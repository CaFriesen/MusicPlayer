using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC_MusicPlayer
{
    class Song
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string PathToFile { get; set; }
        public string Lyrics { get; set; }
        public Artist Performer { get; set; }

        public Song(string name, int year, Artist performer, string pathToFile)
        {

        }

        public override string ToString()
        {
            //TODO: Make usefull
            return base.ToString();
        }
    }
}
