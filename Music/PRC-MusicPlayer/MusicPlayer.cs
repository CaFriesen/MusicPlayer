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

        private List<Song> playing;
        public int playingIndex { get; set; }
        private bool playingSong = false;

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

        public IReadOnlyList<Song> Playing
        {
            get { return this.playing.AsReadOnly(); }
        }

        public MusicPlayer()
        {
            songs = new List<Song>();
            artists = new List<Artist>();
            playlists = new List<Playlist>();
            playing = new List<Song>();
        }

        public void Add(Artist artist)
        {
            if (artist == null)
                return;

            artists.Add(artist);
        }

        public void Add(Song song)
        {
            if (song == null)
                return;

            songs.Add(song);
        }

        public void Add(Playlist playlist)
        {
            if (playlist == null)
                return;

            playlists.Add(playlist);
        }

        public void Remove(Playlist playlist)
        {
            if (playlist == null)
                return;

            playlists.Remove(playlist);
        }

        public void Play(Song song)
        {
            if (song == null)
                return;

            playing.Clear();
            playing.Add(song);
            playingIndex = 0;
            playingSong = true;
        }

        public void Play(Playlist playlist)
        {
            if (playlist == null)
                return;

            playing.Clear();
            playing.AddRange(playlist.Songs);
            playingIndex = 0;
            playingSong = true;
        }

        public Song IsPlaying()
        {
            return playingSong ? playing[playingIndex] : null;
        }

        public void StopPlaying()
        {
            playingSong = false;
        }
    }
}
