using System;

namespace DDD.Domain.Core.Models
{
    public abstract class EntityAudit : Entity
    {
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public void SetEntityAuditValues(EntityAudit entityAudit)
        {
            if (entityAudit == null)
                return;

            CreatedAt = entityAudit.CreatedAt;
            CreatedBy = entityAudit.CreatedBy;
            UpdatedAt = entityAudit.UpdatedAt;
            UpdatedBy = entityAudit.UpdatedBy;
        }
    }
}
