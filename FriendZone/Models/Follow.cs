using System;
using FriendZone.Interfaces;

namespace FriendZone.Models
{
    public class Follow : IDbItem<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FollowingId { get; set; }
        public string FollowerId { get; set; }
    }
}