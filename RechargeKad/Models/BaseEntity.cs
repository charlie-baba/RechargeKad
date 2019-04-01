using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeKad.Model
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public virtual Boolean Active { get; set; } = true;

        public virtual Boolean Deleted { get; set; } = false;

        public virtual DateTime? CreateDate { get; set; } = DateTime.Now;

        public virtual DateTime? LastModified { get; set; }
        
    }
}
