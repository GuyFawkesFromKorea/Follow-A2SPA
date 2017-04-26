using Humanizer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2SPA.Helpers
{
    public static class VariableNames
    {
        public static string CamelizedName(this ModelExpression modelExpression)
        {
            var className = modelExpression.Metadata.ContainerType.Name;
            var propertyName = modelExpression.Name;

            return className.Camelize() + "." + propertyName.Camelize();
        }
    }
}
