﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IAdminModel
    {
        DataTable Queue();
        DataTable UserList();
    }
}
