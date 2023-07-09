using System;
using System.Collections.Generic;

class Video
{
    public string _title;
    public string _author;
    public int _duration;
    public List<Comment> Comments;

    public Video(string title, string author, int duartion)
    {
        _title = title;
        _author = author;
        _duration = duartion;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int NumberComments()
    {
        return Comments.Count;
    }
}