using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Models.Result
{
    public class DetailResult<T>
    {
        public T Item { get; set; }
        public bool IsDisabled { get; set; }
    }
}
