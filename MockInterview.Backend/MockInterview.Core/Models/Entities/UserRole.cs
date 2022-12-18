using MockInterview.Core.Models.Common;

namespace MockInterview.Core.Models.Entities
{
    /// <summary>
    /// Represents system user role
    /// </summary>
    public class UserRole : IEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Date Created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date Last Time Updateed
        /// </summary>
        public DateTime DateLastModified { get; set; }

        /// <summary>
        /// Updated By User Id
        /// </summary>
        public long? UpdatedByUserId { get; set; }
    }
}
