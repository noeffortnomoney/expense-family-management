using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EFM.Common.Helpers
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        protected PropertyInfo nameProperty;
        private Type resourceType;

        public LocalizedDisplayNameAttribute(string displayName)
            : base(displayName)
        {
        }

        public Type NameResourceType
        {
            get
            {
                return resourceType;
            }

            set
            {
                resourceType = value;
                nameProperty = resourceType.GetProperty(base.DisplayName, BindingFlags.Static | BindingFlags.Public);
            }
        }

        public override string DisplayName
        {
            get
            {
                if (nameProperty != null)
                {
                    return (string)nameProperty.GetValue(nameProperty.DeclaringType, null);
                }

                return base.DisplayName;
            }
        }
    }
}