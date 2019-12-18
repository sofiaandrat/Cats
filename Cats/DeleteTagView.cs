using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class DeleteTagView
    {
        public DeleteTagView() { }
        public void deleteTag(int tagId)
        {
            UserProfilerPresenter userProfilerPresenter = new UserProfilerPresenter();
            userProfilerPresenter.deleteTag(tagId);
        }
    }
}
