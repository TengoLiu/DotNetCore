﻿using System;
using System.Collections.Generic;
using System.Text;
using TengoDotNetCore.DAL.Impl.MyDbContext;
using TengoDotNetCore.Models;

namespace TengoDotNetCore.DAL.Impl {

    public class UserDAL : IUserDAL {

        private TengoDbContext db;

        public UserDAL(TengoDbContext db) {
            this.db = db;
        }

        public int Delete(int id) {
            throw new NotImplementedException();
        }

        public List<User> GetPageList(int page, int pageSize) {
            throw new NotImplementedException();
        }

        public User GetUserById() {
            throw new NotImplementedException();
        }

        public User GetUserByPhone() {
            throw new NotImplementedException();
        }

        public int Insert(User user) {
            throw new NotImplementedException();
        }

        public List<User> List() {
            throw new NotImplementedException();
        }

        public User Update(User user) {
            throw new NotImplementedException();
        }
    }
}
