using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeI1
{
    class User
    {
        private static uint nextUserId = 0;
        public uint UserId { get { return UserId; } set { } }

        public User()
        {
            UserId = nextUserId++;
        }

    }
}
