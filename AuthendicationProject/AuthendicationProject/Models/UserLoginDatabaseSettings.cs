using System;
namespace LoginProject.Models
{
	public class UserLoginDatabaseSettings
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";

        public string DatabaseName { get; set; } = "Signin";

        public string LoginCollectionName { get; set; } = "Signin";
    }
}

