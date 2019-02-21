using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC_MusicPlayer
{
    class Playlist
    {
        public string Name { get; set; }
        private List<Song> songs;

        public IReadOnlyList<Song> Songs
        {
            get { return this.songs.AsReadOnly(); }
        }

        public Playlist(string name)
        {
            Name = name;
            songs = new List<Song>();
        }

        public void Add(Song song)
        {

        }

        public void Add(List<Song> songs)
        {

        }

        public void Remove(Song song)
        {

        }

        public override string ToString()
        {
            //TODO: Make usefull output
            return base.ToString();
        }
    }
}
