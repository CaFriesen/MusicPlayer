using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC_MusicPlayer
{
    class MusicPlayer
    {
        private List<Song> songs;
        private List<Artist> artists;
        private List<Playlist> playlists;

        public IReadOnlyList<Song> Songs
        {
            get { return this.songs.AsReadOnly(); }
        }

        public IReadOnlyList<Artist> Artists
        {
            get { return this.artists.AsReadOnly(); }
        }

        public IReadOnlyList<Playlist> Playlists
        {
            get { return this.playlists.AsReadOnly(); }
        }

        public MusicPlayer()
        {
            songs = new List<Song>();
            artists = new List<Artist>();
            playlists = new List<Playlist>();
        }

        public void Add(Artist artist)
        {

        }

        public void Add(Song song)
        {

        }

        public void Add(Playlist playlist)
        {

        }

        public void Remove(Playlist playlist)
        {

        }

        public void Play(Song song)
        {

        }

        public void Play(Playlist playlist)
        {

        }

        public Song IsPlaying()
        {
            return null;
        }

        public void StopPlaying()
        {

        }
    }
}
