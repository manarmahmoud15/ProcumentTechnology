using ADomain.Entities.Entity;

namespace Domain.Entities.Entity
{
    public class BaseService :IBaseService
    {
        private DBHandler _DB;
        private int _userName;

        #region IInitializer
        public void Initialize(int userName)
        {
            _userName = userName;
        }
        #endregion


        protected DBHandler db
        {
            get
            {
                return _DB ?? (_DB = new DBHandler());
            }
        }

    }
}
