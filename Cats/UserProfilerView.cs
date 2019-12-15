using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class UserProfilerView
    {
        public UserProfilerView() { }
        public void AddFeeder(int UserId)
        {
            AddFeeder form = new AddFeeder(UserId);
            form.Show();
        }
    }
}
