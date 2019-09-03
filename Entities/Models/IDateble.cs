using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public interface IDeletable
    {
        Nullable<bool>  IsDelete { get; set; }
        Nullable<DateTime> DelitingDate { get; set; }
    }
}
