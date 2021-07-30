using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    // 355: https://leetcode-cn.com/problems/design-twitter/
    public sealed class Twitter
    {
        static int timeStamp = 0;
        Dictionary<int, User> userDic = new Dictionary<int, User>();

        /** Initialize your data structure here. */
        public Twitter()
        {

        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (!userDic.ContainsKey(userId))
                userDic.Add(userId, new User(userId));
            userDic[userId].Post(tweetId);
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            var res = new List<int>();
            if (!userDic.ContainsKey(userId))
                return res;

            // make a priority queue
            var pq = new SortedDictionary<int, Twitt>();
            foreach (var user in userDic[userId].Followed)
            {
                var h = userDic[user].Head;
                if (h != null)
                {
                    pq.Add(h.Time, h);
                }
            }

            // get result
            while (pq.Count > 0)
            {
                var last = pq.Last().Value;
                pq.Remove(last.Time);
                if (last.Next != null)
                {
                    var next = last.Next;
                    pq.Add(next.Time, next);
                }
                res.Add(last.Id);
                if (res.Count == 10)
                    break;
            }
            return res;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (!userDic.ContainsKey(followerId))
                userDic.Add(followerId, new User(followerId));
            if (!userDic.ContainsKey(followeeId))
                userDic.Add(followeeId, new User(followeeId));
            userDic[followerId].Follow(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (userDic.ContainsKey(followerId))
            {
                userDic[followerId].Unfollow(followeeId);
            }
        }

        class Twitt
        {
            public Twitt(int time, int id)
            {
                Time = time;
                Id = id;
            }

            public int Time { get; set; }
            public int Id { get; set; }
            public Twitt Next { get; set; }
        }

        class User
        {
            public User(int id)
            {
                Id = id;
                Followed = new HashSet<int>();
                Followed.Add(id);
            }

            public int Id { get; set; }
            public HashSet<int> Followed { get; private set; }
            public Twitt Head { get; set; }

            public void Follow(int id)
            {
                Followed.Add(id);
            }

            public void Unfollow(int id)
            {
                if (id != Id)
                    Followed.Remove(id);
            }

            public void Post(int twitId)
            {
                timeStamp++;
                var t = new Twitt(timeStamp, twitId);
                t.Next = Head;
                Head = t;
            }
        }
    }
}