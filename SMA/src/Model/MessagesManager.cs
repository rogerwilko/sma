using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.src.Model
{
    // classe singleton de gestion des différents messages olfactifs utilisés par les fourmis pour communiquer
    class MessagesManager
    {
        private static MessagesManager _instance;

        public static MessagesManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessagesManager();

                return MessagesManager._instance;
            }

        }

        private MessagesManager()
        {
        }


        // messages olfactifs
        private List<MessageOlfactif> _messages = new List<MessageOlfactif>();

        public List<MessageOlfactif> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

    }
}
