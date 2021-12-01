using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Enums
{
    public enum StatusEnums
    {
        Published = 1,
        New = 2,
        Passive = 3,
        WaitingForApproval = 4,
        Ready= 5,
        UnPublished = 6,
        Removed = 7,
        Trashed = 99
    }
}