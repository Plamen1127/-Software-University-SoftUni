﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Atributes;

namespace ValidationAttributes;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type objType = obj.GetType();

        PropertyInfo[] propertyInfos = objType.GetProperties()
            .Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
            .ToArray();

        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            IEnumerable<MyValidationAttribute> attributes = propertyInfo
                .GetCustomAttributes(true)
                .Where(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.GetType()))
                .Cast<MyValidationAttribute>();

            foreach (var attribute in attributes)
            {
                if (!attribute.IsValid(propertyInfo.GetValue(obj)))
                {
                    return false;
                }
            }
        }

        return true;
    }
}