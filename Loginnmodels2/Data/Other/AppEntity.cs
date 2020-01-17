using System;
namespace Loginnmodels2.Data
{
    

    public interface IAppEntity
    {
        Guid Id { get; set; }

        DateTime CreatedOn { get; set; }

        Guid CreatedBy { get; set; }

        DateTime ModifiedOn { get; set; }

        Guid ModifiedBy { get; set; }

        byte[] RowVersion { get; set; }

        bool IsDeleted { get; set; }
    }

    public abstract class AppEntity : IAppEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public Guid ModifiedBy { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
