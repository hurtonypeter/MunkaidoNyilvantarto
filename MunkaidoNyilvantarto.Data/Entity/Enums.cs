using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Data.Entity
{
    public enum RoleType
    {
        Manager,
        Worker
    }

    public enum IssueState
    {
        New,
        Inprogress,
        Blocked,
        Testing,
        Ready
    }
}
