using Int20h.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int20h.DAL.Entities
{
    public class Question : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt {  get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
