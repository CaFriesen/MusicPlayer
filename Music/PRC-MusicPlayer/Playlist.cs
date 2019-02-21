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
            if (song == null)
                return;

            songs.Add(song);
        }

        public void Add(List<Song> songs)
        {
            if (songs.Count <= 0)
                return;

            foreach (Song song in songs)
            {
                this.songs.Add(song);
            }
        }

        public void Remove(Song song)
        {
            this.songs.RemoveAll(s => s.Equals(song));
        }

        public void Remove(int songIndex)
        {
            if (songIndex < songs.Count && songIndex >= 0)
            {
                songs.RemoveAt(songIndex);
            }
        }

        public override string ToString()
        {
            return Name + " | Songs: " + songs.Count;
        }
    }
}
