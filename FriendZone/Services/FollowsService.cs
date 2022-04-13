using System;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
    public class FollowsService
    {

        private readonly FollowsRepository _repo;

        public FollowsService(FollowsRepository repo)
        {
            _repo = repo;
        }

        private Follow Get(int id)
        {
            Follow found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid ID");
            }
            return found;
        }

        internal Follow Create(Follow followData)
        {
            Follow exists = _repo.Get(followData.FollowingId, followData.FollowerId);
            if (exists != null)
            {
                return exists;
            }
            return _repo.Create(followData);
        }

        internal void Delete(int followId, string userId)
        {
            Follow found = Get(followId);
            if (found.FollowerId != userId)
            {
                throw new Exception("You do not have permission to do that");
            }
            _repo.Delete(followId);
        }
    }
}