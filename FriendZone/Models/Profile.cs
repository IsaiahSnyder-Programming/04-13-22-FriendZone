using System;
using FriendZone.Interfaces;

namespace FriendZone.Models
{
    public class Profile : IDbItem<string>
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }

    public class ProfileFollowViewModel : Profile
    {
        public string FollowId { get; set; }
    }
}