using System.Diagnostics;
using Microsoft.VisualBasic;

namespace _0_Framework.Domain
{
    public class BaseEntity
    {
        public long Id { get; private set; }

        public DateTime CreationDate { get; private set; }
    }
}
