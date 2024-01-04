using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.VM.NewFolder
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
