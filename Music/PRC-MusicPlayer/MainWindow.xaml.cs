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

namespace PRC_MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MusicPlayer musicPlayer;

        public MainWindow()
        {
            InitializeComponent();
            musicPlayer = new MusicPlayer();
        }

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
            if(lbPlaylist.SelectedItem != null)
            {
                musicPlayer.Play(lbPlaylist.SelectedItem as Playlist);
            }
            else
            {
                if(lbSongs.SelectedItem != null)
                {
                    musicPlayer.Play(lbSongs.SelectedItem as Song);
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
