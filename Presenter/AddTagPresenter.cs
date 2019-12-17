using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AddTagPresenter:IAddTagPresenter
    {
        public AddTagPresenter() { }
        public void AddTag(int feederId, string tagStr)
        {
            DataBaseTags dataBaseTags = new DataBaseTags();
            dataBaseTags.AddTag(feederId, tagStr);
        }
    }
}
