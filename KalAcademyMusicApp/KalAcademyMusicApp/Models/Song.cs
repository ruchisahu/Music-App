﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace KalAcademyMusicApp.Models
{
    public class Song
    {
        private string _songPath;

        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string ImagePath { get; set; }
        public string SongPath
        {
            get => _songPath;
            set
            {
                // removes \ from existing playlist files
                _songPath = value;
                if(!string.IsNullOrEmpty(_songPath) && _songPath.StartsWith('\\'))
                {
                    _songPath = _songPath.Substring(1);
                }
            }
        }
        public bool IsFavorite { get; set; }

        public Symbol GetSymbol()
        {
            // interim solution until the next stable commit;
            // this should be sitting in a view model object that encapsulates a song object and this property
            return IsFavorite ? Symbol.UnFavorite : Symbol.Favorite;
        }

        private Song()
        {
            // disable usage of the default constructor
        }

        public Song(string name, string artist, string album, string imagePath, string mp3Path, bool isFavorite)
        {
            Name = name;
            Artist = artist;
            Album = album;
            ImagePath = imagePath;
            SongPath = mp3Path;
            IsFavorite = isFavorite;
        }

        public Song(Song source)
        {
            Name = source.Name;
            Artist = source.Artist;
            Album = source.Album;
            ImagePath = source.ImagePath;
            SongPath = source.SongPath;
            IsFavorite = source.IsFavorite;
        }

        public void Update(Song source)
        {
            Name = source.Name;
            Artist = source.Artist;
            Album = source.Album;
            ImagePath = source.ImagePath;
            SongPath = source.SongPath;
            IsFavorite = source.IsFavorite;
        }
    }
}
