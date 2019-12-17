using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class AddTagView
    {
        public AddTagView() { }
        public void AddTag(int feederId, string tagStr)
        {
            AddTagPresenter addTagPresenter = new AddTagPresenter();
            addTagPresenter.AddTag(feederId, tagStr);
        }
    }
}
