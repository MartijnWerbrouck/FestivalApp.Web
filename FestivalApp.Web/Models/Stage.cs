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
    public class Stage
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
    }
}
