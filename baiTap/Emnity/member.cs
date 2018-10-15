using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baiTap.Emnity
{
    class member
    {
        private string _userName;
        private string _email;
        private string _phone;

        public string userName { get => _userName; set => _userName = value; }
        public string email { get => _email; set => _email = value; }
        public string phone { get => _phone; set => _phone = value; }
    }
}
