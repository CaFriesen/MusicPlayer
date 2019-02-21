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
                MessageBox.Show("Please correct the name or birthday");
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
    }
}
