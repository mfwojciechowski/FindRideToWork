using System;

namespace FindRideToWork.Core.Domain
{
    public class Friends
    {
        public Guid UserFriendId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool xDel { get; set; }

        public Friends()
        {

        }
    }
}