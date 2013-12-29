﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    public class Band
    {
        private String _ID;
        public String ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }

        private String _Name;
        public String Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        private String _Picture;
        public String Picture {
            get {
                return _Picture;
            }
            set {
                _Picture = value;
            }
        }

        private String _PictureURL;
        public String PictureURL {
            get {
                return _PictureURL;
            }
            set {
                _PictureURL = value;
            }
        }

        private String _Description;
        public String Description {
            get {
                return _Description;
            }
            set {
                _Description = value;
            }
        }

        private String _Twitter;
        public String Twitter {
            get {
                return _Twitter;
            }
            set {
                _Twitter = value;
            }
        }

        private String _Facebook;
        public String Facebook {
            get {
                return _Facebook;
            }
            set {
                _Facebook = value;
            }
        }
    }
}
