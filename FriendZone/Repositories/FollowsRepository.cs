using System.Data;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
    public class FollowsRepository
    {

        private readonly IDbConnection _db;

        public FollowsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Follow Get(int id)
        {
            string sql = @"
            SELECT *
            FROM follows 
            WHERE id = @Id";
            return _db.QueryFirstOrDefault<Follow>(sql, new { id });
        }

        internal Follow Get(string followingId, string followerId)
        {
            string sql = @"
            SELECT *
            FROM follows
            WHERE followingId = @FollowingId AND followerId = @FollowerId
            ";
            return _db.QueryFirstOrDefault<Follow>(sql, new { followingId, followerId });
        }

        internal Follow Create(Follow followData)
        {
            string sql = @"
            INSERT INTO follows
            (followerId, followingId)
            VALUES
            (@FollowerId, @FollowingId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, followData);
            followData.Id = id;
            return followData;
        }

        public void Delete(int id)
        {
            string sql = @"
            DELETE FROM follows
            WHERE id = @id
            LIMIT 1
            ";
            _db.Execute(sql, new { id });
        }
    }
}