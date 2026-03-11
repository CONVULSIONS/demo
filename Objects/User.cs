namespace Demo.Objects
{
    public static class User
    {
        public static string Name { get; private set; }
        public static int RoleId { get; private set; }

        public static void SetUser(string name, int roleId)
        {
            Name = name;
            RoleId = roleId;
        } 
        public static void CleareUser()
        {
            User.Name = "";
            User.RoleId = 0;
        }
    }
}

