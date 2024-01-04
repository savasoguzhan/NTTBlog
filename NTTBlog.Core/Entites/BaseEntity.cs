using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Core.Entites
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid(); // Override icin virtual tanimlama

        public virtual string CreatedBy { get; set; } = "undefined";
               
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
               
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; }
               
        public virtual DateTime DeletedDate { get; set; }
    }
}
