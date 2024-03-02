﻿using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class SessionAnswer:IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}