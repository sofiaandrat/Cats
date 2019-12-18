using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IDataBaseTags
    {
        DataTable showTags(int feederId);
        void AddTag(int feederId, string tagStr);
        void deleteTag(int tagId);
    }
}
