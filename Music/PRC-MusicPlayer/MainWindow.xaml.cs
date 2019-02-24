using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace PRC_MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MusicPlayer musicPlayer;
        MediaPlayer Music;
        Uri link;

        public MainWindow()
        {
            InitializeComponent();
            musicPlayer = new MusicPlayer();
            Music = new MediaPlayer();
        }

        //this function is from Stackoverflow i copied it since its not a crucial part of the assignment
        //Credit to: https://stackoverflow.com/questions/194863/random-date-in-c-sharp
       /* DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(1995, 1, 1);
            DateTime end = new DateTime(2000, 12, 25);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
#endif*/

        private void BtnAddArtist_Click(object sender, RoutedEventArgs e)
        {
            if (txtArtistname.Text != "" && dtBirthday.SelectedDate != null)
            {
                musicPlayer.Add(new Artist(txtArtistname.Text, dtBirthday.SelectedDate.Value.Date));
            }
            else
            {
                MessageBox.Show("Please fill in all the boxes");
            }
            UpdateLists();
        }

        private void UpdateLists()
        {
            lbPlayingSongs.ItemsSource = null;
            lbPlaylist.ItemsSource = null;
            lbSongs.ItemsSource = null;
            cbArtist.ItemsSource = null;

            if (musicPlayer.IsPlaying() != null)
            {
                lbPlayingSongs.ItemsSource = musicPlayer.Playing;
            }
            lbPlaylist.ItemsSource = musicPlayer.Playlists;
            lbSongs.ItemsSource = musicPlayer.Songs;
            cbArtist.ItemsSource = musicPlayer.Artists;
        }

        private void BtnNewSongPlaylist_Click(object sender, RoutedEventArgs e)
        {
            if(tbName.Text == "")
            {
                MessageBox.Show("No name entered");
                return;
            }

            foreach (Playlist playlistName in musicPlayer.Playlists)
            {
                if(playlistName.Name == tbName.Text)
                {
                    MessageBox.Show("Playlist already exist");
                    return;
                }
            }

            List<Song> pl = new List<Song>();
            foreach (Song song in lbSongs.SelectedItems)
            {
                pl.Add(song);
            }

            Playlist playlist = new Playlist(tbName.Text);
            playlist.Add(pl);
            musicPlayer.Add(playlist);
            UpdateLists();
        }

        private void BtnAddSong_Click(object sender, RoutedEventArgs e)
        {
            if (txtSongName.Text != "" && txtSongYear.Text != "" && cbArtist.SelectedItem != null && txtSongPathToFile.Text != "")
            {
                int year;
                Artist artist = cbArtist.SelectedItem as Artist;
                if (Int32.TryParse(txtSongYear.Text, out year))
                {
                    musicPlayer.Add(new Song(txtSongName.Text, year, artist, txtSongPathToFile.Text));
                }
                else
                {
                    MessageBox.Show("Year needs to be a number");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the boxes");
            }
            UpdateLists();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {

            if (lbPlaylist.SelectedItem != null)
            {
                musicPlayer.Play(lbPlaylist.SelectedItem as Playlist);
                Music.Stop();
                Song song = musicPlayer.Playing[musicPlayer.playingIndex];
                try
                {
                    link = new Uri(song.PathToFile);
                    Music.Open(link);
                    Music.Play();
                }
                catch (UriFormatException uriFormatException)
                {
                    MessageBox.Show(uriFormatException.Message);
                }
            }
            else
            {
                if(lbSongs.SelectedItem != null)
                {
                    musicPlayer.Play(lbSongs.SelectedItem as Song);
                    Song song = (Song)lbSongs.SelectedItem;
                    try
                    {
                        link = new Uri(song.PathToFile);
                        Music.Open(link);
                        Music.Play();
                    }
                    catch(UriFormatException uriFormatException)
                    {
                        MessageBox.Show(uriFormatException.Message);
                    }

                }
                else
                {
                    MessageBox.Show("nothing selected");
                }
            }
            UpdateSongLabel();
            UpdateLists();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            Music.Stop();
            musicPlayer.StopPlaying();
            UpdateSongLabel();
            UpdateLists();
        }

        private void UpdateSongLabel()
        {
            if (musicPlayer.IsPlaying() == null)
            {
                lblPlaying.Content = "Now playing: ";
            }
            else
            {
                lblPlaying.Content = "Now playing: " + musicPlayer.IsPlaying().Name;

            }
        }

        private void BtnPrevSong_Click(object sender, RoutedEventArgs e)
        {
            if (musicPlayer.playingIndex - 1 < 0)
            {
                MessageBox.Show("There is no previous song");
            }
            else
            {
                musicPlayer.playingIndex--;
                Music.Stop();
                Song song = musicPlayer.Playing[musicPlayer.playingIndex];
                try
                {
                    link = new Uri(song.PathToFile);
                    Music.Open(link);
                    Music.Play();
                }
                catch (UriFormatException uriFormatException)
                {
                    MessageBox.Show(uriFormatException.Message);
                }
            }
            UpdateSongLabel();
            UpdateLists();
        }

        private void BtnNextSong_Click(object sender, RoutedEventArgs e)
        {
            if (musicPlayer.playingIndex + 1 >= musicPlayer.Playing.Count)
            {
                MessageBox.Show("There is no next song");
            }
            else
            {
                musicPlayer.playingIndex++;
                Music.Stop();
                Song song = musicPlayer.Playing[musicPlayer.playingIndex];
                try
                {
                    link = new Uri(song.PathToFile);
                    Music.Open(link);
                    Music.Play();
                }
                catch (UriFormatException uriFormatException)
                {
                    MessageBox.Show(uriFormatException.Message);
                }
            }
            UpdateSongLabel();
            UpdateLists();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Playlist playlist in musicPlayer.Playlists)
            {
                if (playlist == lbPlaylist.SelectedItem)
                {
                    musicPlayer.Remove(playlist);
                    UpdateLists();
                    return;
                }
            }
        }
    }
}
/*
#if DEBUG
            InsertTestData();
#endif
        }

        //If we are not in debug mode this function will not exist
#if DEBUG
        private void InsertTestData()
        {
            //Create random fucntion so we get new data every startup
            Random tempRandom = new Random();

            musicPlayer.Add(new Artist("Henk", RandomDay(tempRandom)));
            musicPlayer.Add(new Artist("Steve", RandomDay(tempRandom)));
            musicPlayer.Add(new Artist("Camiel", RandomDay(tempRandom)));
            musicPlayer.Add(new Artist("Max", RandomDay(tempRandom)));
            musicPlayer.Add(new Artist("Frank", RandomDay(tempRandom)));
            musicPlayer.Add(new Artist("Dave", RandomDay(tempRandom)));

            for (int i = 0; i < 30; i++)
            {
                musicPlayer.Add(new Song("Example " + (i + 1), tempRandom.Next(2000,2019) ,musicPlayer.Artists[tempRandom.Next(musicPlayer.Artists.Count)], "Documents/Music"));
            }

            for (int i = 0; i < 5; i++)
            {
                Playlist pl = new Playlist("Example pl " + (i + 1));
                pl.Add(musicPlayer.Songs[tempRandom.Next(musicPlayer.Songs.Count)]);
                pl.Add(musicPlayer.Songs[tempRandom.Next(musicPlayer.Songs.Count)]);
                pl.Add(musicPlayer.Songs[tempRandom.Next(musicPlayer.Songs.Count)]);
                pl.Add(musicPlayer.Songs[tempRandom.Next(musicPlayer.Songs.Count)]);
                pl.Add(musicPlayer.Songs[tempRandom.Next(musicPlayer.Songs.Count)]);
                musicPlayer.Add(pl);
            }

            UpdateLists();*/