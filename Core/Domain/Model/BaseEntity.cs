using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BaseEntity<TK>
    {
        public TK Id { get; set; } = default!;
    }
}
