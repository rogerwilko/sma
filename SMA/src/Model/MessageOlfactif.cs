using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.src.Model
{
    class MessageOlfactif
    {
        // case X
        private int _posX;

        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }

        // case Y
        private int _posY;

        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }

        // portée (en cases)
        private int _portee;

        public int Portee
        {
            get { return _portee; }
            set { _portee = value; }
        }

        // message
        private int _msg;

        public int Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }


        public MessageOlfactif(int msg, int posx, int posy, int portee = 1)
        {
            _msg = msg;
            _posX = posx;
            _posY = posy;
            _portee = portee;
        }
    }
}
