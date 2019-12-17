using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class UserProfilerPresenter
    {
        public UserProfilerPresenter() { }
        public DataTable updateFeederList(int userId)
        {
            DataBaseFeeder dataBaseFeeder = new DataBaseFeeder();
            return dataBaseFeeder.update(userId);
        }

        public DataTable showTags(int feederId)
        {
            DataBaseTags dataBaseTags = new DataBaseTags();
            return dataBaseTags.showTags(feederId);
        }
    }
}
