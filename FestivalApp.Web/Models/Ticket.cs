﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    public class Ticket
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

        private String _Ticketholder;
        public String Ticketholder {
            get {
                return _Ticketholder;
            }
            set {
                _Ticketholder = value;
            }
        }

        private String _TicketholderEmail;
        public String TicketholderEmail {
            get {
                return _TicketholderEmail;
            }
            set {
                _TicketholderEmail = value;
            }
        }

        private TicketType _TicketType;
        public TicketType TicketType {
            get {
                return _TicketType;
            }
            set {
                _TicketType = value;
            }
        }

        private int _Amount;
        public int Amount {
            get {
                return _Amount;
            }
            set {
                _Amount = value;
            }
        }
    }
}
