using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    interface IUserProfilerPresenter
    {
        DataTable updateFeederList();
        DataTable showTags(int feederId);
    }
}
