using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Common
{
	public static class DataActions
	{
		public static DataTable ConvertToDatatable<T>(List<T> data)
		{
			PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
			DataTable table = new DataTable();
			for (int i = 0; i < props.Count; i++)
			{
				PropertyDescriptor prop = props[i];
				if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
					table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
				else
					table.Columns.Add(prop.Name, prop.PropertyType);
			}
			object[] values = new object[props.Count];
			foreach (T item in data)
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = props[i].GetValue(item);
				}
				table.Rows.Add(values);
			}
			return table;
		}

		public static DataTable ConvertToDataTable<T>(IEnumerable<T> varlist)
		{
			DataTable dtReturn = new DataTable();

			// column names
			PropertyInfo[] oProps = null;

			if (varlist == null) return dtReturn;

			foreach (T rec in varlist)
			{
				// Use reflection to get property names, to create table, Only first time, others
				if (oProps == null)
				{
					oProps = ((Type)rec.GetType()).GetProperties();
					foreach (PropertyInfo pi in oProps)
					{
						Type colType = pi.PropertyType;

						if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
						== typeof(Nullable<>)))
						{
							colType = colType.GetGenericArguments()[0];
						}

						dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
					}
				}

				DataRow dr = dtReturn.NewRow();

				foreach (PropertyInfo pi in oProps)
				{
					dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
					(rec, null);
				}

				dtReturn.Rows.Add(dr);
			}
			return dtReturn;
		}
	}
}