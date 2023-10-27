using Microsoft.Maui.Graphics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_project
{
    public class DBTrans
    {
        public string path;
        private SQLiteConnection con;

        public DBTrans(string _dbpath)
        {
            path = _dbpath;
        }
        public void Init()
        {
            con = new SQLiteConnection(path);
            con.CreateTable<Note>();
            con.CreateTable<User>();

        }
        //GET
        public List<Note> GetNotes()
        {
            Init();
            return con.Table<Note>().Where(n => n.User == LoginClass.Email).ToList(); 

        }
        public List<User> GetUsers()
        {
            Init();
            return con.Table<User>().ToList();

        }
       

        //ADD

        public void InsertNote(Note n)
        {
            con = new SQLiteConnection(path);
            con.Insert(n);

        }
        public void InsertUser(User u)
        {
            con = new SQLiteConnection(path);
            con.Insert(u);

        }
        //DELETE
        public void DeleteNote(int id)
        {
            con = new SQLiteConnection(path);
            con.Delete(new Note { Id = id });

        }

        public void DeleteAllNote()
        {
            con = new SQLiteConnection(path);
            con.DeleteAll<Note>();

        }
        //UPDATE
        public void UpdateNote(int i, string title, string des, DateTime date, string user, string file) {
            con = new SQLiteConnection(path);
            con.Update(new Note { Id = i, Title= title, Description = des, Date = date, User=user, File=file});

        }


        public bool IsLogin()
        {
            GetUsers();
            var result = con.Table<User>().Where(u => u.Email == LoginClass.Email).Where(u => u.Password == LoginClass.Password).FirstOrDefault();

            if (result == null )
            {
                return false;

            }
            return true;
        }

        public string FindFileName()
        {
            GetNotes();
            var temp = con.Table<Note>().Where(n=>n.Id == Detail.Id).FirstOrDefault();
            Detail.File = temp.File;
            return Detail.File;
        }

    }
}