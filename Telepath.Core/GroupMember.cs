using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class GroupMember
    {
        [Key, Column(Order = 0)]
        public int ThinkMemberId { get; set; }

        [Key, Column(Order = 1)]
        public int ThinkGroupId { get; set; }

        public ThinkMember ThinkMember { get; set; }

        public ThinkGroup ThinkGroup { get; set; }
    }
}
