using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Remote.Web.DTO
{
    public abstract class IdModel
    {
        [Key]
        public int? Id { get; set; }

        #region -Object Overrides
        public static bool operator ==(IdModel o1, IdModel o2)
        {
            if ((o1 as object) != null)
            {
                return o1.Equals(o2);
            }

            return (o2 as object) == null;
        }

        public static bool operator !=(IdModel o1, IdModel o2)
        {
            return !(o1 == o2);
        }

        public override bool Equals(object otherObj)
        {
            var otherAsDbModel = otherObj as IdModel;
            if (otherAsDbModel == null)
            {
                return false;
            }

            return this.GetHashCode() == otherObj.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (Id.HasValue)
            {
                return (this.GetType().FullName + Id.Value.ToString()).GetHashCode();
            }

            return base.GetHashCode();
        }
        #endregion
    }
}