using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMap.EntityCore
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
