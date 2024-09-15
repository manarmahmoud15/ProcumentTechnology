using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poratl.WebApi.Abstraction
{
    public static class Api_Routes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = "/" + Root + "/" + Version;


        public static class UsersJobStatus
        {
            public const string GetAll = Base + "/UsersJobStatus/GetAll";

            public const string Update = Base + "/UsersJobStatus/Update";

            public const string DeleteList = Base + "/UsersJobStatus/DeleteList";

            public const string Delete = Base + "/UsersJobStatus/delete";

            public const string Get = Base + "/UsersJobStatus/getById";

            public const string Create = Base + "/UsersJobStatus";

            public const string Block = Base + "/UsersJobStatus/Block";
        }

        public static class UsersJobCategory
        {
            public const string GetAll = Base + "/UsersJobCategory/GetAll";

            public const string Update = Base + "/UsersJobCategory/Update";

            public const string DeleteList = Base + "/UsersJobCategory/DeleteList";

            public const string Delete = Base + "/UsersJobCategory/delete";

            public const string Get = Base + "/UsersJobCategory/getById";

            public const string Create = Base + "/UsersJobCategory";

            public const string Block = Base + "/UsersJobCategory/Block";
        }

        public static class Communications
        {
            public const string GetAll = Base + "/Communications/GetAll";

            public const string Update = Base + "/Communications/Update";

            public const string DeleteList = Base + "/Communications/DeleteList";

            public const string Delete = Base + "/Communications/delete";

            public const string Get = Base + "/Communications/getById";

            public const string Create = Base + "/Communications";

            public const string Block = Base + "/Communications/Block";
        }

        public static class Bill
        {
            public const string GetAll = Base + "/Bill/GetAll";

            public const string Update = Base + "/Bill/Update";

            public const string DeleteList = Base + "/Bill/DeleteList";

            public const string Delete = Base + "/Bill/delete";

            public const string Get = Base + "/Bill/getById";

            public const string Create = Base + "/Bill";

            public const string Block = Base + "/Bill/Block";
        }

        public static class Users
        {
            public const string GetAll = Base + "/Users/GetAll";

            public const string Update = Base + "/Users/Update";

            public const string DeleteList = Base + "/Users/DeleteList";

            public const string Delete = Base + "/Users/delete";

            public const string Get = Base + "/Users/getById";

            public const string Create = Base + "/Users";

            public const string Block = Base + "/Users/Block";
            public const string Login = Base + "/Users/Login";
        }

        public static class UsersRoles
        {
            public const string GetAll = Base + "/UsersRoles/GetAll";

            public const string Update = Base + "/UsersRoles/Update";

            public const string DeleteList = Base + "/UsersRoles/DeleteList";

            public const string Delete = Base + "/UsersRoles/delete";

            public const string Get = Base + "/UsersRoles/getById";

            public const string Create = Base + "/UsersRoles";

            public const string Block = Base + "/UsersRoles/Block";
        }

        public static class UsersJobs
        {
            public const string GetAll = Base + "/UsersJobs/GetAll";

            public const string Update = Base + "/UsersJobs/Update";

            public const string DeleteList = Base + "/UsersJobs/DeleteList";

            public const string Delete = Base + "/UsersJobs/delete";

            public const string Get = Base + "/UsersJobs/getById";

            public const string Create = Base + "/UsersJobs";

            public const string Block = Base + "/UsersJobs/Block";
        }

        public static class Electronics
        {
            public const string GetAll = Base + "/Electronics/GetAll";

            public const string Update = Base + "/Electronics/Update";

            public const string DeleteList = Base + "/Electronics/DeleteList";

            public const string Delete = Base + "/Electronics/delete";

            public const string Get = Base + "/Electronics/getById";

            public const string Create = Base + "/Electronics";

            public const string Block = Base + "/Electronics/Block";
        }

        public static class FreelancerService
        {
            public const string GetAll = Base + "/FreelancerService/GetAll";

            public const string Update = Base + "/FreelancerService/Update";

            public const string DeleteList = Base + "/FreelancerService/DeleteList";

            public const string Delete = Base + "/FreelancerService/delete";

            public const string Get = Base + "/FreelancerService/getById";

            public const string Create = Base + "/FreelancerService";

            public const string Block = Base + "/FreelancerService/Block";
        }

        public static class Company
        {
            public const string GetAll = Base + "/Company/GetAll";

            public const string Update = Base + "/Company/Update";

            public const string DeleteList = Base + "/Company/DeleteList";

            public const string Delete = Base + "/Company/delete";

            public const string Get = Base + "/Company/getById";

            public const string Create = Base + "/Company";

            public const string Block = Base + "/FreelancerReview/Block";
        }

        public static class Report
        {
            public const string GetAll = Base + "/Report/GetAll";

            public const string Update = Base + "/Report/Update";

            public const string DeleteList = Base + "/Report/DeleteList";

            public const string Delete = Base + "/Report/delete";

            public const string Get = Base + "/Report/getById";

            public const string Create = Base + "/Report";

            public const string Block = Base + "/Report/Block";
        }

        public static class Product
        {
            public const string GetAll = Base + "/Product/GetAll";

            public const string Update = Base + "/Product/Update";

            public const string DeleteList = Base + "/Product/DeleteList";

            public const string Delete = Base + "/Product/delete";

            public const string Get = Base + "/Product/getById";

            public const string Create = Base + "/Product";

            public const string Block = Base + "/Product/Block";
        }

        public static class Price
        {
            public const string GetAll = Base + "/Price/GetAll";

            public const string Update = Base + "/Price/Update";

            public const string DeleteList = Base + "/Price/DeleteList";

            public const string Delete = Base + "/Price/delete";

            public const string Get = Base + "/Price/getById";

            public const string Create = Base + "/Price";

            public const string Block = Base + "/Price/Block";
        }


        public static class Roles
        {
            public const string GetAll = Base + "/Roles/GetAll";

            public const string Update = Base + "/Roles/Update";

            public const string DeleteList = Base + "/Roles/DeleteList";

            public const string Delete = Base + "/Roles/delete";

            public const string Get = Base + "/Roles/getById";

            public const string Create = Base + "/Roles/Create";

            public const string Block = Base + "/Roles/Block";

            public const string Read = Base + "/Roles/Read";
        }


    }
}
