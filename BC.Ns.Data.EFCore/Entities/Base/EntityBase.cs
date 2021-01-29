using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Ns.Data.EFCore.Entities.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = CreatedOn;
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
