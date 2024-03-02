﻿using Int20h.DAL.Entities.Abstract;

namespace Int20h.DAL.Entities
{
    public class TeacherInformation : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Group> MentorGroups { get; set; }
    }
}
